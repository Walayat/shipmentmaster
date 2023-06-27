using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Services.ShipperService.DTOs
{
	public class ShipperBaseDto
	{
		public int shipper_id { get; set; }
		public string shipper_name { get; set; } = null!;
	}
}
