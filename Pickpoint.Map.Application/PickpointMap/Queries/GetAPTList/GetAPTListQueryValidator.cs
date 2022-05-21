using FluentValidation;


namespace Pickpoint.Map.Application.PickpointMap.Queries.GetAPTList
{
    public class GetAPTListQueryValidator : AbstractValidator<GetAPTListQuery>
    {
        public GetAPTListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
