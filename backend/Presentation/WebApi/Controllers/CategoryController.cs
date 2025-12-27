using Application.CQRS.Commands.CategoryCommands;
using Application.CQRS.Commands.PostCommands;
using Application.CQRS.Handlers.Modify.Categories;
using Application.CQRS.Results.CategoryResults;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Categories;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CreateCategoryCommandHandler _createCategoryCommandHandler;
        private UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private SoftDeleteCategoryCommandHandler _softDeleteCategoryCommandHandler;

        private GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private GetCategoriesQueryHandler _getCategorysQueryHandler;

        private readonly IValidator<CreateCategoryCommand> _createValidator;
        private readonly IValidator<UpdateCategoryCommand> _updateValidator;

        public CategoryController(
            CreateCategoryCommandHandler createCategoryCommandHandler,
            UpdateCategoryCommandHandler updateCategoryCommandHandler,
            RemoveCategoryCommandHandler removeCategoryCommandHandler,
            SoftDeleteCategoryCommandHandler softDeleteCategoryCommandHandler,
            GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,
            GetCategoriesQueryHandler getCategorysQueryHandler,
            IValidator<CreateCategoryCommand> createValidator,
            IValidator<UpdateCategoryCommand> updateValidator)
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _softDeleteCategoryCommandHandler = softDeleteCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategorysQueryHandler = getCategorysQueryHandler;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<GetCategoriesQueryResult> values = await _getCategorysQueryHandler.Handle();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            GetCategoryByIdQueryResult result = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var validationResult = await _createValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors
                    .Select(e => new { e.PropertyName, e.ErrorMessage }));
            }

            await _createCategoryCommandHandler.Handle(command);

            return Ok("Veri eklendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var validationResult = await _updateValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors
                    .Select(e => new { e.PropertyName, e.ErrorMessage }));
            }

            var result = await _updateCategoryCommandHandler.Handle(command);

            if(result == null)
            {
                return NotFound("Kategori bulunamadı");
            }

            return Ok("Veri güncelleme basarılıdır");
        }

        [HttpPut("pacify/{id}")]
        public async Task<IActionResult> SoftDeleteCategory(int id)
        {
            var result = await _softDeleteCategoryCommandHandler.Handle(new SoftDeleteCategoryCommand(id));

            if (result == null)
            {
                return NotFound("Kategori bulunamadı");
            }

            return Ok("Veri pasif hale getirildi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));

            if (result == null)
            {
                return NotFound("Kategori bulunamadı");
            }

            return Ok("Veri silimiştir.");
        }
    }
}
