using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJ.Service.Services.ProductServices;
using PRJ.Service.Services.ProductServices.DTOs;
using PRJ.Service.Services.User.DTOs;
using PRJ.Utility;

namespace ShoppingPortal.Controllers
{
	[Authorize]
	[Route("api")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		[Route("products/{id}")]
		public async Task<IActionResult> GetProductById(int id)
		{
			return Ok(await _productService.Get(id));
		}

		[HttpGet]
		[Route("products")]
		public async Task<IActionResult> GetAllProducts()
		{
			return Ok(await _productService.GetAll());
		}

		[HttpPost]
		[Route("products")]
		public async Task<IActionResult> SaveProduct(ProductInputDto dto)
		{
			var userId = Convert.ToInt32(User.FindFirst(SessionStrings.UserId).Value);
			return Ok(await _productService.Create(userId, dto));
		}

		[HttpPut]
		[Route("products/{id}")]
		public async Task<IActionResult> UpdateProduct(int id, ProductInputDto dto)
		{
			var userId = Convert.ToInt32(User.FindFirst(SessionStrings.UserId).Value);
			dto.ProductId = id;
			return Ok(await _productService.Update(userId, dto));
		}

		[HttpDelete]
		[Route("products/{id}")]
		public async Task<IActionResult> RemoveProduct(int id)
		{
			return Ok(await _productService.Delete(id));
		}
	}
}
