﻿using Application.Features.CarModels.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Dynamic;
using Core.Persistance.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarModels.Queries.GetListByDynamic;


public class GetListByDynamicCarModelQuery : IRequest<GetListResponse<GetListByDynamicCarModelListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicCarModelQueryHandler : IRequestHandler<GetListByDynamicCarModelQuery, GetListResponse<GetListByDynamicCarModelListItemDto>>
    {
        private readonly ICarModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicCarModelQueryHandler(ICarModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListByDynamicCarModelListItemDto>> Handle(GetListByDynamicCarModelQuery request, CancellationToken cancellationToken)
        {
            Paginate<CarModel> models = await _modelRepository.GetListByDynamicAsync(
                 request.DynamicQuery,
                 include: m => m.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),
                 index: request.PageRequest.PageIndex,
                 size: request.PageRequest.PageSize
                 );

            var response = _mapper.Map<GetListResponse<GetListByDynamicCarModelListItemDto>>(models);

            return response;


        }
    }
}
