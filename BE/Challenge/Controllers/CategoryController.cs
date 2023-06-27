using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJ.Service.Services.CategoryServices;

namespace ShoppingPortal.Controllers
{
	[Authorize]
	[Route("api")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService) 
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		[Route("categories")]
		public async Task<IActionResult> GetAllCategories()
		{
			return Ok(await _categoryService.GetAll());
		}
	}
}
