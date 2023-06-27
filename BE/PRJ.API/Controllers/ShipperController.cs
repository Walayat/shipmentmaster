using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJ.Service.Services.ShipperService;

namespace PRJ.API.Controllers
{
	[Route("api")]
	[ApiController]
	[AllowAnonymous]
	public class ShipperController : ControllerBase
	{
		private readonly IShipperService _shipperService;
		public ShipperController(IShipperService shipperService)
		{
			_shipperService = shipperService;
		}

		[HttpGet]
		[Route("shippers")]
		public async Task<IActionResult> Get()
		{
			return Ok(await _shipperService.GetAllShippers());
		}
	}
}
