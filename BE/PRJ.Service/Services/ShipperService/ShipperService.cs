using AutoMapper;
using PRJ.Repository.Repositories;
using PRJ.Repository.UnitOfWorks;
using PRJ.Service.Services.ShipperService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Services.ShipperService
{
	public class ShipperService : IShipperService
	{
		private readonly IMapper _mapper;
		private readonly IRepository<SHIPPER> _shipmentRepository;
		private readonly IUnitOfWork _unitOfWork;

		public ShipperService(IMapper mapper, IRepository<SHIPPER> shipmentRepository, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_shipmentRepository = shipmentRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<OutputDTO<List<ShipperResponseDto>>> GetAllShippers()
		{
			var result = await _unitOfWork.ShipperRepo.GetAll();
			var response = _mapper.Map<List<ShipperResponseDto>>(result);

			return new OutputDTO<List<ShipperResponseDto>>() {Data = response, HttpStatusCode = ((int)HttpStatusCode.OK), Message = "shippers get successfully", Succeeded = true};
		}
	}
}
