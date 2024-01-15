using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Aplication.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Aplication.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Aplication.Features.CQRS.Queries.CarQueries;

namespace UdemyCarBook.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarqueryHandler _getCarqueryCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarfindByIdQueryHandler;

        public CarsController(CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarqueryHandler getCarqueryCommandHandler, GetCarByIdQueryHandler getCarfindByIdQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarqueryCommandHandler = getCarqueryCommandHandler;
            _getCarfindByIdQueryHandler = getCarfindByIdQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarqueryCommandHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var values = await _getCarfindByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(values);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Araç bilgisi Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Araç Bilgisi Silindi");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Araç Bilgisi Güncellendi");
        }
    }
}
