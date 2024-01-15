using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Queries.BrandQueries;
using UdemyCarBook.Aplication.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public GetBrandByIdQueryHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery byIdQuery)
        {
            var values=await _brandRepository.GetByIdAsync(byIdQuery.Id);
            return new GetBrandByIdQueryResult
            {
                BrandID = values.BrandID,
                BrandName = values.BrandName,
            };
        }
    }
}
