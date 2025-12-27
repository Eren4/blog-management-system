using Application.CQRS.Commands.CommentCommands;
using Application.CQRS.Commands.TagCommands;
using Application.CQRS.Handlers.Modify.Tags;
using Application.CQRS.Handlers.Read.Tags;
using Application.CQRS.Queries.TagQueries;
using Application.CQRS.Results.TagResults;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private CreateTagCommandHandler _createTagCommandHandler;
        private UpdateTagCommandHandler _updateTagCommandHandler;
        private RemoveTagCommandHandler _removeTagCommandHandler;
        private SoftDeleteTagCommandHandler _softDeleteTagCommandHandler;

        private GetTagByIdQueryHandler _getTagByIdQueryHandler;
        private GetTagsQueryHandler _getTagsQueryHandler;

        private readonly IValidator<CreateTagCommand> _createValidator;
        private readonly IValidator<UpdateTagCommand> _updateValidator;

        public TagController(
            CreateTagCommandHandler createTagCommandHandler,
            UpdateTagCommandHandler updateTagCommandHandler,
            RemoveTagCommandHandler removeTagCommandHandler,
            SoftDeleteTagCommandHandler softDeleteTagCommandHandler,
            GetTagByIdQueryHandler getTagByIdQueryHandler,
            GetTagsQueryHandler getTagsQueryHandler,
            IValidator<CreateTagCommand> createValidator,
            IValidator<UpdateTagCommand> updateValidator)
        {
            _createTagCommandHandler = createTagCommandHandler;
            _updateTagCommandHandler = updateTagCommandHandler;
            _removeTagCommandHandler = removeTagCommandHandler;
            _softDeleteTagCommandHandler = softDeleteTagCommandHandler;
            _getTagByIdQueryHandler = getTagByIdQueryHandler;
            _getTagsQueryHandler = getTagsQueryHandler;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            List<GetTagsQueryResult> values = await _getTagsQueryHandler.Handle();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            GetTagByIdQueryResult result = await _getTagByIdQueryHandler.Handle(new GetTagByIdQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
            var validationResult = await _createValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors
                    .Select(e => new { e.PropertyName, e.ErrorMessage }));
            }

            await _createTagCommandHandler.Handle(command);

            return Ok("Veri eklendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        {
            var validationResult = await _updateValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors
                    .Select(e => new { e.PropertyName, e.ErrorMessage }));
            }

            var result = await _updateTagCommandHandler.Handle(command);

            if (result == null)
            {
                return NotFound("Etiket bulunamadı");
            }

            return Ok("Veri güncelleme basarılıdır");
        }

        [HttpPut("pacify/{id}")]
        public async Task<IActionResult> SoftDeleteTag(int id)
        {
            var result = await _softDeleteTagCommandHandler.Handle(new SoftDeleteTagCommand(id));

            if (result == null)
            {
                return NotFound("Etiket bulunamadı");
            }

            return Ok("Veri pasif hale getirildi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var result = await _removeTagCommandHandler.Handle(new RemoveTagCommand(id));

            if (result == null)
            {
                return NotFound("Etiket bulunamadı");
            }

            return Ok("Veri silimiştir.");
        }
    }
}
