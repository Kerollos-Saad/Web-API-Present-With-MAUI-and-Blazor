using Demo.Api.Data;
using Demo.Api.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly DemoDbContext _dbContext;

		public ProductController(DemoDbContext dbContext) => _dbContext = dbContext;

		[HttpGet]
		public ActionResult<IEnumerable<Product>> Get()
		{
			return _dbContext.Products;
		}

		[HttpPost("{id}")]
		public async Task<ActionResult<Product?>> GetById(int id)
		{
			return await _dbContext.Products.Where( x => x.Id == id).SingleOrDefaultAsync();
		}

		[HttpPost]
		public async Task<ActionResult> Create(Product product)
		{
			await _dbContext.Products.AddAsync(product);
			await _dbContext.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
		}

		[HttpPut]
		public async Task<ActionResult> Update(Product product)
		{
			_dbContext.Products.Update(product);
			await _dbContext.SaveChangesAsync();

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var product = await GetById(id);
			if (product.Value is null)
				return NotFound();

			_dbContext.Products.Remove(product.Value);
			await _dbContext.SaveChangesAsync();

			return Ok();
		}
	}
}
