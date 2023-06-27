using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Services.QuotableService.DTOs
{
	public class QuotableBaseDto
	{
		public string _id { get; set; } = null!;
		public string content { get; set; } = null!;
		public string author { get; set; } = null!;
		public List<string> tags { get; set; } = null!;
		public string authorSlug { get; set; } = null!;
		public int length { get; set; }
		public string dateAdded { get; set; } = null!;
		public string dateModified { get; set; } = null!;
	}
}
