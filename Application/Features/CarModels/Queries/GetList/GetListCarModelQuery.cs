using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarModels.Queries.GetList;

public class GetListCarModelQuery : IRequest<GetListResponse<GetListCarModelListItemDto>>
{
    public PageRequest PageRequest { get;set;}

    public class GetListModelQueryHandler : IRequestHandler<GetListCarModelQuery, GetListResponse<GetListCarModelListItemDto>>
    {
        private readonly ICarModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetListModelQueryHandler(ICarModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCarModelListItemDto>> Handle(GetListCarModelQuery request, CancellationToken cancellationToken)
        {
            Paginate<CarModel> carModels = await _modelRepository.GetListAsync(
                    include: m => m.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize
                ) ;

            var response = _mapper.Map<GetListResponse<GetListCarModelListItemDto>>(carModels);

            return response;
        }
    }
}
