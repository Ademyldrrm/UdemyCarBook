﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Results.BannerResult;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public GetBannerQueryHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values= await _bannerRepository.GetAllAsync();
            
            return values.Select(x=> new GetBannerQueryResult
            {
                BannerID = x.BannerID,
                Description = x.Description,
                Title = x.Title,
                VideoDescription = x.VideoDescription,
                VideoUrl=x.VideoUrl
            }).ToList();
        }
    }
}
