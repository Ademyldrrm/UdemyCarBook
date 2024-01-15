using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _aboutRepository;

        public CreateAboutCommandHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
        public async Task Handle(CreateAboutCommand aboutCommand)
        {
            await _aboutRepository.CreateAsync(new About
            {
                Description = aboutCommand.Description,
                ImageUrl = aboutCommand.ImageUrl,
                Title = aboutCommand.Title
            });
        }
    }
}
