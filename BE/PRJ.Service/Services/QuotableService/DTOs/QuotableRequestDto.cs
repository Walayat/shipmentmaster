using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Services.QuotableService.DTOs
{
	public class QuotableRequestDto
	{
		public string? author { get; set; }
		public int page { get; set; } = 1;
		public int limit { get; set; } = 30;
		public string? category { get; set; }
	}
}
