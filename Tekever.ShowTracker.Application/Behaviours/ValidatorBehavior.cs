using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;


namespace BeeExplorers.Application.Behaviours
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;


        public ValidatorBehavior(
            IValidator<TRequest>[] validators

        )
        {
            _validators = validators;
        }

		public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			throw new NotImplementedException();
		}
	}
}