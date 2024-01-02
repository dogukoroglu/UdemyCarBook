using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
	public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
	{
		private readonly ICarRepository _repository;

		public GetCarCountQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarCount();
			return new GetCarCountQueryResult
			{
				CarCount = values,
			};
		}
	}
}
