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
	public class SHIPMENT
	{
		[Key]
		public int shipment_id { get; set; }

		[Column(TypeName = "varchar(100)")]
		[Required]
		public string shipment_description { get; set; } = null!;

		[Column(TypeName = "decimal(18,2)")]
		public decimal shipment_weight { get; set; }

		public virtual SHIPPER SHIPPER { get; set; } = null!;
		public virtual SHIPMENT_RATE SHIPMENT_RATE { get; set; } = null!;
		public virtual CARRIER CARRIER { get; set; } = null!;
	}
}