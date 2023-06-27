using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using PRJ.Repository.Repositories;
using PRJ.Repository.UnitOfWorks;
using PRJ.Service.Services.ShipmentService.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.Services.ShipmentService
{
	public class ShipmentService : IShipmentService
	{
		private readonly IMapper _mapper;
		private readonly IRepository<SHIPMENT> _shipmentRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IConfiguration _configuration;
		private readonly string _connection;

		public ShipmentService(IMapper mapper, IRepository<SHIPMENT> shipmentRepository, IUnitOfWork unitOfWork, IConfiguration configuration)
		{
			_mapper = mapper;
			_shipmentRepository = shipmentRepository;
			_unitOfWork = unitOfWork;
			_configuration = configuration;
			_connection = configuration.GetSection("ASPNETCORE_ENVIRONMENT").GetChildren().ToString() == ApplicationConstants.Development
						? configuration.GetConnectionString(ApplicationConstants.Development)
						: configuration.GetConnectionString(ApplicationConstants.Production);
		}

		public async Task<OutputDTO<List<ShipmentResponseDto>>> GetShipmentDetails(int shipperId)
		{
			var response = new List<ShipmentResponseDto>();
			try
			{
				using (var connection = new SqlConnection(_connection))
				{
					var sp_SelectChargesParameters = new
					{
						@shipper_id = shipperId
					};
					var parameters = new DynamicParameters(sp_SelectChargesParameters);
					var result = await connection.QueryAsync<ShipmentResponseDto>("Shipper_Shipment_Details", parameters, commandType: CommandType.StoredProcedure);
					response = result.ToList();
				}
				return new OutputDTO<List<ShipmentResponseDto>>() {Message = "shipments with details get successfully", Succeeded = true, HttpStatusCode = 200, Data = response };

			}
			catch (Exception ex)
			{
				return new OutputDTO<List<ShipmentResponseDto>>() { Message = ex.Message, Succeeded = false, HttpStatusCode = ((int)HttpStatusCode.NotFound), Data = response };
			}
		}
	}
}
