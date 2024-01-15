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
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _carRepository;

        public CreateCarCommandHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task Handle(CreateCarCommand createCarCommand)
        {
            await _carRepository.CreateAsync(new Car
            {
                BigImageUrl = createCarCommand.BigImageUrl,
                Luggage = createCarCommand.Luggage,
                BrandID = createCarCommand.BrandID,
                Fuel = createCarCommand.Fuel,
                Km = createCarCommand.Km,
                Model = createCarCommand.Model,
                Seat = createCarCommand.Seat,
                Transmission = createCarCommand.Transmission,
                CoverImageUrl = createCarCommand.CoverImageUrl,

            });
        }
    }
}
