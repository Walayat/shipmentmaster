using PRJ.Service.Services.ShipperService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Services.ShipperService
{
	public interface IShipperService
	{
		public Task<OutputDTO<List<ShipperResponseDto>>> GetAllShippers();
	}
}
