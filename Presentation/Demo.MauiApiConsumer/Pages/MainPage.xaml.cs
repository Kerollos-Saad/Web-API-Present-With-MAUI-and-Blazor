using Demo.ApiClient;
using Demo.ApiClient.Models.ApiModels;
using Demo.MauiApiConsumer.Pages;

namespace Demo.MauiApiConsumer
{
	public partial class MainPage : ContentPage
	{
		private readonly DemoApiClientService _apiClient;

		public MainPage(DemoApiClientService apiClientService)
		{
			InitializeComponent();
			_apiClient = apiClientService;
		}

		private async Task LoadProducts()
		{
			var products = await _apiClient.GetProductsAsync();
			productListView.ItemsSource = products;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await LoadProducts();
		}

		private async void btnAdd_Clicked(object? sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new AddEditProduct(_apiClient, null));
		}

		private async void btnShowProducts_Clicked(object? sender, EventArgs e)
		{
			await LoadProducts();
		}

		private async void productListView_SelectionChanged(object? sender, SelectionChangedEventArgs e)
		{
			var product = e.CurrentSelection.FirstOrDefault() as Product;
			if (product == null)
				return;

			// Clear selection immediately to allow re-selecting the same item
			((CollectionView)sender).SelectedItem = null;

			// Show action sheet
			var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

			switch (action)
			{
				case "Edit":
					await Navigation.PushModalAsync(new AddEditProduct(_apiClient, product));
					break;
				case "Delete":
					await _apiClient.DeleteProduct(product.Id);
					await LoadProducts();
					break;
			}
		}
	}
}
