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
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task Handle(UpdateBannerCommand bannerCommand)
        {
            var values = await _bannerRepository.GetByIdAsync(bannerCommand.BannerID);
            values.BannerID = bannerCommand.BannerID;   
            values.VideoUrl = bannerCommand.VideoUrl;
            values.Title = bannerCommand.Title;
            values.VideoDescription = bannerCommand.VideoDescription; 
            values.Description = bannerCommand.Description; 
            await _bannerRepository.UpdateAsync(values);
        }
    }
}
