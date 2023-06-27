using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.DataAccess.Entities
{
	public class SHIPMENT_RATE
	{
		[Key]
		public int shipment_rate_id { get; set; }
		[Column(TypeName = "varchar(10)")]
		[Required]
		public string shipment_rate_class { get; set; } = null!;

		[Column(TypeName = "varchar(25)")]
		[Required]
		public string shipment_rate_description { get; set; } = null!;

		public List<SHIPMENT> SHIPMENTS { get; set; } = null!;
	}
}
