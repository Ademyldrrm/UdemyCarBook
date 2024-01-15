using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _carRepository;

        public RemoveCarCommandHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task Handle(RemoveCarCommand removeCarCommand)
        {
            var values= await _carRepository.GetByIdAsync(removeCarCommand.Id);
           await _carRepository.RemoveAsync(values);
        }
    }
}
