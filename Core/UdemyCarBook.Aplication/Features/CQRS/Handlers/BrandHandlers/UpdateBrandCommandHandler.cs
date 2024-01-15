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
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public UpdateBrandCommandHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task Handle(UpdateBrandCommand brandCommand)
        {
            var values = await _brandRepository.GetByIdAsync(brandCommand.BrandID);
            values.BrandName = brandCommand.BrandName;
           await _brandRepository.UpdateAsync(values);
            
        }
    }
}
