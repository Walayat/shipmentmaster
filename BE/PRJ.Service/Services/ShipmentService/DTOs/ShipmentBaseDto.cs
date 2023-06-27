using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Services.ShipmentService.DTOs
{
	public class ShipmentBaseDto
	{
		public int shipment_id { get; set; }
		public string shipment_description { get; set; } = null!;
		public decimal shipment_weight { get; set; }
	}
}
