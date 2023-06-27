using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Services.ShipmentService.DTOs
{
	public class ShipmentResponseDto : ShipmentBaseDto
	{
		public string shipper_name { get; set; } = null!;
		public string carrier_name { get; set; } = null!;
		public string shipment_rate_description { get; set; } = null!;
	}
}
