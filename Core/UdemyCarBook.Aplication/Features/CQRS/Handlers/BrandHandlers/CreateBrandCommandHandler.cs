using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public CreateBrandCommandHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task Handle(CreateBrandCommand command)
        {
            await _brandRepository.CreateAsync(new Brand
            {
                BrandName = command.BrandName,

            });
        }
    }
}
