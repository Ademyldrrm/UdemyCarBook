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
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public RemoveBrandCommandHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task Handle(RemoveBrandCommand command)
        {
            var values=await _brandRepository.GetByIdAsync(command.Id);
            _brandRepository.RemoveAsync(values);   
        }
    }
}
