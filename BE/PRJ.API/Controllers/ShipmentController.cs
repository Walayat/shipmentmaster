using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJ.Service.Services.ShipmentService;

namespace PRJ.API.Controllers
{
	[AllowAnonymous]
	[Route("api")]
	[ApiController]
	public class ShipmentController : ControllerBase
	{
		private readonly IShipmentService _shipmentService;
		public ShipmentController(IShipmentService shipmentService)
		{
			_shipmentService = shipmentService;
		}

		[HttpGet]
		[Route("shipments/{shipperId}")]
		public async Task<IActionResult> Get(int shipperId)
		{
			return Ok(await _shipmentService.GetShipmentDetails(shipperId));
		}
	}
}
