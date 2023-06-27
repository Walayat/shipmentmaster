using PRJ.Service.Services.ShipmentService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Services.ShipmentService
{
	public interface IShipmentService
	{
		public Task<OutputDTO<List<ShipmentResponseDto>>> GetShipmentDetails(int shipperId);
	}
}
