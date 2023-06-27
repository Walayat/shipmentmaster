using PRJ.Service.Services.QuotableService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Services.QuotableService
{
	public interface IQuotableService
	{
		public Task<OutputDTO<QuotableBaseDto>> GetRandomQuote();
		public Task<OutputDTO<QuotableResponseDto>> GetQuotesByAutor(QuotableRequestDto requestDto);
	}
}
