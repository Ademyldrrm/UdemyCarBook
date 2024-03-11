using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Aplication.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Aplication.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Aplication.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Aplication.Features.CQRS.Handlers.CategoryHandlers;

namespace UdemyCarBook.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _createCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly  GetCategoryQueryHandler _getCategoryQueryHandler;

        public CategoriesController(CreateCategoryCommandHandler createCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return Ok(values);

        }
        [HttpPost]
        public async Task<IActionResult> CareateCategory(CreateCategoryCommand categoryCommand)
        {
            await _createCommandHandler.Handle(categoryCommand);
            return Ok("Category eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand categoryCommand)
        {
            await _updateCategoryCommandHandler.Handle(categoryCommand);
            return Ok("Category Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCatecory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Category Silindi");

        }
    }
}
