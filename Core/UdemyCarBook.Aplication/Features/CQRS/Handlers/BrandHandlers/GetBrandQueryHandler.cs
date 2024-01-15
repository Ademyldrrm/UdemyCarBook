using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public GetBrandQueryHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values= await _brandRepository.GetAllAsync();
            return values.Select(x=> new GetBrandQueryResult
            {
                BrandID = x.BrandID,
                BrandName = x.BrandName
            }).ToList();
        }
    }
}
