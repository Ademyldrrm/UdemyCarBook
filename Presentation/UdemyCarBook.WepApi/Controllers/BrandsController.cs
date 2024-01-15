using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Aplication.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Aplication.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Aplication.Features.CQRS.Queries.BrandQueries;

namespace UdemyCarBook.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;

        public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler,
            RemoveBrandCommandHandler removeBrandCommandHandler,
            GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);

        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand brandCommand)
        {
            await _createBrandCommandHandler.Handle(brandCommand);
            return Ok("Marka eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand brandCommand)
        {
            await _updateBrandCommandHandler.Handle(brandCommand);
            return Ok("Marka Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Marka Silindi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByBrand(int id)
        {
          var values=  await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(values);
        }
    }
}
