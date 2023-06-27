using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJ.Service.Services.PurchaseServices;
using PRJ.Service.Services.PurchaseServices.DTOs;
using PRJ.Utility;

namespace ShoppingPortal.Controllers
{
	[Authorize]
	[Route("api")]
	[ApiController]
	public class PurchaseController : ControllerBase
	{
		private readonly IPurchaseService _purchaseService;
		public PurchaseController(IPurchaseService purchaseService)
		{
			_purchaseService = purchaseService;
		}

		[HttpGet]
		[Route("purchase/{id}")]
		public async Task<IActionResult> GetProductById(int id)
		{
			return Ok(await _purchaseService.Get(id));
		}

		[HttpPost]
		[Route("purchase")]
		public async Task<IActionResult> SavePurchaseOrder(PurchaseInputDto dto)
		{
			var userId = Convert.ToInt32(User.FindFirst(SessionStrings.UserId).Value);
			return Ok(await _purchaseService.Create(userId,dto));
		}
	}
}
