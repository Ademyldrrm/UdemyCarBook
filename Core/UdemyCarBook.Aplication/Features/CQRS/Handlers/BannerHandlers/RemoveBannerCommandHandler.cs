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
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public RemoveBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task Handle(RemoveBannerCommand removeBannerCommand)
        {
            var values = await _bannerRepository.GetByIdAsync(removeBannerCommand.Id);
           await _bannerRepository.RemoveAsync(values);
        }
    }
}
