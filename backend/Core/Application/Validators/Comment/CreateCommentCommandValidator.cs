using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CQRS.Commands.CommentCommands;
using FluentValidation;

namespace Application.Validators.Comment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Text)
                .NotEmpty().WithMessage("İçerik boş olamaz");
        }
    }
}
