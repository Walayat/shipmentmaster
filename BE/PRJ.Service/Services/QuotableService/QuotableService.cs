using AutoMapper;
using PRJ.Service.Services.QuotableService.DTOs;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Services.QuotableService
{
	public class QuotableService : IQuotableService
	{
		private readonly IMapper _mapper;
		private static readonly HttpClient httpClient = new HttpClient();

		public QuotableService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public async Task<OutputDTO<QuotableBaseDto>> GetRandomQuote()
		{
			var response = new QuotableBaseDto();
			string apiUrl = Quotable.BaseUrl + Quotable.GetRandomQuoteURL;

			try
			{
				var client = new RestClient(apiUrl);
				var request = new RestRequest(apiUrl, Method.Get);

				request.AddHeader("accept", "*/*");
				request.AddHeader("Content-Type", "application/json");

				var responseResult = await client.ExecuteAsync(request);
				var responseJson = responseResult.Content;

				if (responseResult.IsSuccessStatusCode)
				{
					response = JsonConvert.DeserializeObject<QuotableBaseDto>(responseJson);
				}
				else
				{
					return new OutputDTO<QuotableBaseDto>() { Data = response, HttpStatusCode = ((int)HttpStatusCode.InternalServerError), Succeeded = false };
				}

				return new OutputDTO<QuotableBaseDto>() { Data = response, HttpStatusCode = ((int)HttpStatusCode.OK), Succeeded = true, Message = "quote get successfully" };
			}
			catch (Exception ex)
			{
				return new OutputDTO<QuotableBaseDto>() { Data = response, HttpStatusCode = ((int)HttpStatusCode.InternalServerError), Succeeded = false, Message = ex.Message };
			}
		}


		public async Task<OutputDTO<QuotableResponseDto>> GetQuotesByAutor(QuotableRequestDto requestDto)
		{
			var response = new QuotableResponseDto();
			string apiUrl = $"{Quotable.BaseUrl + Quotable.GetQuotesByAuthorURL}?author={requestDto.author}&page={requestDto.page}&limit={requestDto.limit}";

			try
			{
				var client = new RestClient(apiUrl);
				var request = new RestRequest(apiUrl, Method.Get);

				request.AddHeader("accept", "*/*");
				request.AddHeader("Content-Type", "application/json");

				var responseResult = await client.ExecuteAsync(request);
				var responseJson = responseResult.Content;

				if (responseResult.IsSuccessStatusCode)
				{
					response = JsonConvert.DeserializeObject<QuotableResponseDto>(responseJson);
					if (!(response is null))
					{
						foreach (var quote in response.results)
						{
							int wordCount = quote.content.Split(' ').Length;

							if (wordCount < 10)
								response.shortResults.Add(quote);
							else if (wordCount >= 10 && wordCount <= 20)
								response.mediumResults.Add(quote);
							else
								response.longResults.Add(quote);
						}
						response.results = new List<Result>();
					}
				}
				else
				{
					return new OutputDTO<QuotableResponseDto>() { Data = response, HttpStatusCode = ((int)HttpStatusCode.InternalServerError), Succeeded = false };
				}

				return new OutputDTO<QuotableResponseDto>() { Data = response, HttpStatusCode = ((int)HttpStatusCode.OK), Succeeded = true, Message = "quote get successfully" };
			}
			catch (Exception ex)
			{
				return new OutputDTO<QuotableResponseDto>() { Data = response, HttpStatusCode = ((int)HttpStatusCode.InternalServerError), Succeeded = false, Message = ex.Message };
			}
		}
	}
}
