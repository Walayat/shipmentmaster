using AutoMapper;
using PRJ.Service.Services.ShipperService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRJ.Service.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
			CreateMap<SHIPPER, ShipperResponseDto>().ReverseMap();
		}
    }
}
