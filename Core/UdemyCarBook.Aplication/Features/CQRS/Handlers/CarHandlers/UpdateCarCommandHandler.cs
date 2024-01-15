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
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _carRepository;

        public UpdateCarCommandHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task Handle(UpdateCarCommand updateCarCommand)
        {
            var values = await _carRepository.GetByIdAsync(updateCarCommand.CarID);
            values.Fuel = updateCarCommand.Fuel;
            values.Transmission = updateCarCommand.Transmission;
            values.BigImageUrl = updateCarCommand.BigImageUrl;
            values.BrandID = updateCarCommand.BrandID;
            values.CoverImageUrl = updateCarCommand.CoverImageUrl;
            values.Km=updateCarCommand.Km;
            values.Luggage = updateCarCommand.Luggage;
            values.Model = updateCarCommand.Model;
            values.Seat = updateCarCommand.Seat;    
            await _carRepository.UpdateAsync(values);   
        }
    }
}
