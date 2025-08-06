using FluentValidation;
using TaskTracker.DTOs;

namespace TaskTracker.UseCases.Validators;

public class CreateTaskValidator : AbstractValidator<CreateTaskDto>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be null or empty");
        RuleFor(x => x.Status).IsInEnum().WithMessage("Status should be valid");
    }
}