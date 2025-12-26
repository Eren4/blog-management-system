using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Commands.PostCommands;
using FluentValidation;

namespace Application.Validators.Post
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("İçerik boş olamaz")
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(p => p.Content)
                .NotEmpty();
        }

    }
}
