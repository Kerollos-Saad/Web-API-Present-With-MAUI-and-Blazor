using Demo.ApiClient;
using Demo.ApiClient.Models.ApiModels;

namespace Demo.MauiApiConsumer.Pages;

public partial class AddEditProduct : ContentPage
{
	private readonly DemoApiClientService _apiClient;
	private Product _product;

	public AddEditProduct(DemoApiClientService apiClient, Product product)
	{
		InitializeComponent();
		_apiClient = apiClient;
		_product = product;
		loadProductDetails();
	}

	private void loadProductDetails()
	{
		if (_product is not null)
		{
			txtProductCode.Text = _product.ProductCode;
			txtProductName.Text = _product.ProductName;
			txtPrice.Text = _product.Price.ToString();
		}
	}

	private async void btnSave_Clicked(object? sender, EventArgs e)
	{
		if (_product is null)
		{
			// Add a new product
			await _apiClient.SaveProduct(new Product
			{
				ProductCode = txtProductCode.Text,
				ProductName = txtProductName.Text,
				Price = decimal.Parse(txtPrice.Text),
			});
		}
		else
		{
			// Update an existing product
			await _apiClient.UpdateProduct(new Product
			{
				Id = _product.Id,
				ProductCode = txtProductCode.Text,
				ProductName = txtProductName.Text,
				Price = decimal.Parse(txtPrice.Text),
			});
		}

		await Navigation.PopModalAsync();
	}

	private async void btnCancel_Clicked(object? sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
}