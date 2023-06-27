using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRJ.Service.Services.QuotableService;
using PRJ.Service.Services.QuotableService.DTOs;

namespace PRJ.API.Controllers
{
	[Route("api")]
	[ApiController]
	[AllowAnonymous]
	public class QuotableController : ControllerBase
	{
		private readonly IQuotableService _quotableService;
		public QuotableController(IQuotableService quotableService)
		{
			_quotableService = quotableService;
		}

		[HttpGet]
		[Route("getRandomQuote")]
		public async Task<IActionResult> Get()
		{
			return Ok(await _quotableService.GetRandomQuote());
		}
		
		[HttpGet]
		[Route("getQuotesByAuthor")]
		public async Task<IActionResult> Get([FromQuery]QuotableRequestDto request)
		{
			return Ok(await _quotableService.GetQuotesByAutor(request));
		}
	}
}
