using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Queries.BannerQueries;
using UdemyCarBook.Aplication.Features.CQRS.Results.AboutResult;
using UdemyCarBook.Aplication.Features.CQRS.Results.BannerResult;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetBannerByIdQueryResult>Handle(GetBannerByIdQuery byIdQuery)
        {
            var values= await _repository.GetByIdAsync(byIdQuery.Id);
            return new GetBannerByIdQueryResult
            {
                BannerID = values.BannerID,
                Title = values.Title,
                Description = values.Description,
                VideoDescription = values.VideoDescription,
                VideoUrl = values.VideoUrl,
            };
            
        }
    }
}
