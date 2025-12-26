using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Commands.PostCommands;
using FluentValidation;

namespace Application.Validators.Post
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz")
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(p => p.Content)
                .NotEmpty().WithMessage("İçerik boş olamaz");
        }
    }
}
