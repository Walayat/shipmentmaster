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
	public class SHIPPER
	{
		[Key]
		public int shipper_id { get; set; }
		[Column(TypeName = "varchar(100)")]
		[Required]
		public string shipper_name { get; set; } = null!;

		public List<SHIPMENT> SHIPMENTS { get; set; } = null!;
	}
}
