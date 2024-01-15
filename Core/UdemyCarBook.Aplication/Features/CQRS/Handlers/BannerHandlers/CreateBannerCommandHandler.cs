using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public CreateBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task Handle(CreateBannerCommand bannerCommand)
        {
            await _bannerRepository.CreateAsync(new Banner
            {
                Description = bannerCommand.Description,
                Title = bannerCommand.Title,
                VideoDescription = bannerCommand.VideoDescription,
                VideoUrl = bannerCommand.VideoUrl,
            });
                
        }
    }
}
