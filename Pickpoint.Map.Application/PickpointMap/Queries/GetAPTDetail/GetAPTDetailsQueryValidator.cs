

using FluentValidation;

namespace Pickpoint.Map.Application.PickpointMap.Queries.GetAPTDetail
{
    public class GetAPTDetailsQueryValidator : AbstractValidator<GetAPTDetailQuery>
    {
        public GetAPTDetailsQueryValidator()
        {
            RuleFor(apt => apt.Id).NotEqual(Guid.Empty);
            RuleFor(apt => apt.UserId).NotEqual(Guid.Empty);
        }
    }
}
