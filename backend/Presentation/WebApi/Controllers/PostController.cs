using Application.CQRS.Commands.PostCommands;
using Application.CQRS.Handlers.Modify.Posts;
using Application.CQRS.Handlers.Read.Posts;
using Application.CQRS.Queries.PostQueries;
using Application.CQRS.Results.PostResults;
using AutoMapper;
using Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private CreatePostCommandHandler _createPostCommandHandler;
        private UpdatePostCommandHandler _updatePostCommandHandler;
        private RemovePostCommandHandler _removePostCommandHandler;
        private SoftDeletePostCommandHandler _softDeletePostCommandHandler;

        private GetPostByIdQueryHandler _getPostByIdQueryHandler;
        private GetPostsQueryHandler _getPostsQueryHandler;

        private readonly IValidator<CreatePostCommand> _createValidator;
        private readonly IValidator<UpdatePostCommand> _updateValidator;

        public PostController(
            CreatePostCommandHandler createPostCommandHandler,
            UpdatePostCommandHandler updatePostCommandHandler,
            RemovePostCommandHandler removePostCommandHandler,
            SoftDeletePostCommandHandler softDeletePostCommandHandler,
            GetPostByIdQueryHandler getPostByIdQueryHandler,
            GetPostsQueryHandler getPostsQueryHandler,
            IValidator<CreatePostCommand> createValidator,
            IValidator<UpdatePostCommand> updateValidator)
        {
            _createPostCommandHandler = createPostCommandHandler;
            _updatePostCommandHandler = updatePostCommandHandler;
            _removePostCommandHandler = removePostCommandHandler;
            _softDeletePostCommandHandler = softDeletePostCommandHandler;
            _getPostByIdQueryHandler = getPostByIdQueryHandler;
            _getPostsQueryHandler = getPostsQueryHandler;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            List<GetPostsQueryResult> values = await _getPostsQueryHandler.Handle();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            GetPostByIdQueryResult result = await _getPostByIdQueryHandler.Handle(new GetPostByIdQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostCommand command)
        {
            var validationResult = await _createValidator.ValidateAsync(command);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors
                    .Select(e => new { e.PropertyName, e.ErrorMessage }));
            }

            await _createPostCommandHandler.Handle(command);

            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(UpdatePostCommand command)
        {
            var validationResult = await _updateValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors
                    .Select(e => new { e.PropertyName, e.ErrorMessage }));
            }

            var result = await _updatePostCommandHandler.Handle(command);

            if (result == null)
            {
                return NotFound("Gönderi bulunamadı");
            }

            return Ok("Veri güncelleme basarılıdır");
        }

        [HttpPut("id")]
        public async Task<IActionResult> SoftDeletePost(int id)
        {
            var result = await _softDeletePostCommandHandler.Handle(new SoftDeletePostCommand(id));

            if (result == null)
            {
                return NotFound("Gönderi bulunamadı");
            }

            return Ok("Veri pasif hale getirildi");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _removePostCommandHandler.Handle(new RemovePostCommand(id));

            if (result == null)
            {
                return NotFound("Gönderi bulunamadı");
            }

            return Ok("Veri silimiştir.");
        }
    }
}
