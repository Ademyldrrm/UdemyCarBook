using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Aplication.Features.CQRS.Results.CarResults;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _carRepository;

        public GetCarByIdQueryHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery byIdQuery)
        {
            var values = await _carRepository.GetByIdAsync(byIdQuery.Id);
            return new GetCarByIdQueryResult
            {
                BigImageUrl = values.BigImageUrl,
                BrandID = values.BrandID,
                CarID = values.CarID,
                CoverImageUrl = values.CoverImageUrl,
                Fuel = values.Fuel,
                Km = values.Km,
                Luggage = values.Luggage,
                Model = values.Model,
                Seat = values.Seat,
                Transmission = values.Transmission,
            };
        }
    }
}
