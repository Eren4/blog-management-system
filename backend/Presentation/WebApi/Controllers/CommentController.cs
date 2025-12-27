using Application.CQRS.Commands.CommentCommands;
using Application.CQRS.Handlers.Modify.Categories;
using Application.CQRS.Handlers.Modify.Comments;
using Application.CQRS.Handlers.Read.Comments;
using Application.CQRS.Queries.CommentQueries;
using Application.CQRS.Results.CommentResults;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private CreateCommentCommandHandler _createCommentCommandHandler;
        private UpdateCommentCommandHandler _updateCommentCommandHandler;
        private RemoveCommentCommandHandler _removeCommentCommandHandler;
        private SoftDeleteCommentCommandHandler _softDeleteCommentCommandHandler;

        private GetCommentByIdQueryHandler _getCommentByIdQueryHandler;
        private GetCommentsQueryHandler _getCommentsQueryHandler;

        private readonly IValidator<CreateCommentCommand> _createValidator;
        private readonly IValidator<UpdateCommentCommand> _updateValidator;

        public CommentController(
            CreateCommentCommandHandler createCommentCommandHandler,
            UpdateCommentCommandHandler updateCommentCommandHandler,
            RemoveCommentCommandHandler removeCommentCommandHandler,
            SoftDeleteCommentCommandHandler softDeleteCommentCommandHandler,
            GetCommentByIdQueryHandler getCommentByIdQueryHandler,
            GetCommentsQueryHandler getCommentsQueryHandler,
            IValidator<CreateCommentCommand> createValidator,
            IValidator<UpdateCommentCommand> updateValidator)
        {
            _createCommentCommandHandler = createCommentCommandHandler;
            _updateCommentCommandHandler = updateCommentCommandHandler;
            _removeCommentCommandHandler = removeCommentCommandHandler;
            _softDeleteCommentCommandHandler = softDeleteCommentCommandHandler;
            _getCommentByIdQueryHandler = getCommentByIdQueryHandler;
            _getCommentsQueryHandler = getCommentsQueryHandler;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            List<GetCommentsQueryResult> values = await _getCommentsQueryHandler.Handle();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            GetCommentByIdQueryResult result = await _getCommentByIdQueryHandler.Handle(new GetCommentByIdQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            var validationResult = await _createValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors
                    .Select(e => new { e.PropertyName, e.ErrorMessage }));
            }

            await _createCommentCommandHandler.Handle(command);

            return Ok("Veri eklendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand command)
        {
            var validationResult = await _updateValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors
                    .Select(e => new { e.PropertyName, e.ErrorMessage }));
            }

            var result = await _updateCommentCommandHandler.Handle(command);

            if(result == null)
            {
                return NotFound("Yorum bulunamadı");
            }

            return Ok("Veri güncelleme basarılıdır");
        }

        [HttpPut("pacify/{id}")]
        public async Task<IActionResult> SoftDeleteComment(int id)
        {
            var result = await _softDeleteCommentCommandHandler.Handle(new SoftDeleteCommentCommand(id));

            if (result == null)
            {
                return NotFound("Yorum bulunamadı");
            }

            return Ok("Veri pasif hale getirildi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await _removeCommentCommandHandler.Handle(new RemoveCommentCommand(id));

            if (result == null)
            {
                return NotFound("Yorum bulunamadı");
            }

            return Ok("Veri silimiştir.");
        }
    }
}
