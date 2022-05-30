using FluentValidation;

namespace Pickpoint.Map.Application.PickpointMap.Commands.CreateAPT
{
    public class CreateAPTValidator : AbstractValidator<CreateAPTCommand>
    {
        public CreateAPTValidator()
        {
            RuleFor(createAPTCommand => createAPTCommand.NumberPoint).NotEmpty().MaximumLength(250);
            RuleFor(createAPTCommand => createAPTCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
