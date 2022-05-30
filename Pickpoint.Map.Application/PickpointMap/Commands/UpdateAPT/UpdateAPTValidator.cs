using FluentValidation;

namespace Pickpoint.Map.Application.PickpointMap.Commands.UpdateAPT
{
    public class UpdateAPTValidator : AbstractValidator<UpdateAPTCommand>
    {
        public UpdateAPTValidator()
        {
            RuleFor(createAPTCommand => createAPTCommand.NumberPoint).NotEmpty().MaximumLength(250);
            RuleFor(createAPTCommand => createAPTCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
