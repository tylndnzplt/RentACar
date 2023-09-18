using Application.Features.Brands.Queries.GetList;
using Application.Features.CarModels.Queries.GetList;
using Core.Application.Responses;
using Core.Persistance.Paging;
using Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CarModels.Queries.GetListByDynamic;

namespace Application.Features.CarModels.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<CarModel, GetListCarModelListItemDto>()
           .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
           .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
           .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name))
           .ReverseMap();
        
        CreateMap<CarModel, GetListByDynamicCarModelListItemDto>()
            .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
            .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
            .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name))
            .ReverseMap();
        
        CreateMap<Paginate<CarModel>, GetListResponse<GetListCarModelListItemDto>>().ReverseMap();
        
        CreateMap<Paginate<CarModel>, GetListResponse<GetListByDynamicCarModelListItemDto>>().ReverseMap();
    }
}
