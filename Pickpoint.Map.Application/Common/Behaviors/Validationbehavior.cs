using FluentValidation;
using MediatR;

namespace Pickpoint.Map.Application.Common.Behaviors
{
    public class Validationbehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>

    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public Validationbehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public IEnumerable<IValidator<TRequest>> Validators => _validators;


        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failrules = Validators
                .Select(validator => validator.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failrules => failrules != null)
                .ToList();
            if (failrules.Count != 0)
            {
                throw new ValidationException(failrules);
            }
            return next();
        }
    }
}
