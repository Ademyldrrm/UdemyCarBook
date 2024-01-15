using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Aplication.Features.CQRS.Results.CarResults;
using UdemyCarBook.Aplication.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Aplication.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarqueryHandler
    {
        private readonly IRepository<Car> _carRepository;

        public GetCarqueryHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<List<GetCarQueryresult>> Handle()
        {
            var values = await _carRepository.GetAllAsync();
            return values.Select(x=> new GetCarQueryresult
            {
                BigImageUrl = x.BigImageUrl,
                BrandID = x.BrandID,
                CarID = x.CarID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel=x.Fuel,
                Km=x.Km,
                Luggage=x.Luggage,
                Model=x.Model,
                Seat=x.Seat,
                Transmission=x.Transmission,
            }).ToList();
        }
    }
}
