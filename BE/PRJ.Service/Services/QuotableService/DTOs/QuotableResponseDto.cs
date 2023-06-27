using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Services.QuotableService.DTOs
{
	public class QuotableResponseDto
	{
		public QuotableResponseDto()
		{
			results = new List<Result>();
			shortResults = new List<Result>();
			mediumResults = new List<Result>();
			longResults = new List<Result>();
		}
		public int count { get; set; }
		public int totalCount { get; set; }
		public int page { get; set; }
		public int totalPages { get; set; }
		public int lastItemIndex { get; set; }
		public List<Result> results { get; set; }
		public List<Result> shortResults { get; set; }
		public List<Result> mediumResults { get; set; }
		public List<Result> longResults { get; set; }
	}

	public class Result
	{
		public Result()
		{
			tags = new List<string>();
		}
		public string _id { get; set; } = null!;
		public string author { get; set; } = null!; 
		public string content { get; set; } = null!;
		public List<string> tags { get; set; }
		public string authorSlug { get; set; } = null!;
		public int length { get; set; }
		public string dateAdded { get; set; } = null!;
		public string dateModified { get; set; } = null!;
	}
}
