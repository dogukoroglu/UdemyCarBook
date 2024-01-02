using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
	public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
	{
		private readonly IStatisticRepository _repository;
		public GetLocationCountQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetLocationCount();
			return new GetLocationCountQueryResult
			{
				LocationCount = value
			};
		}
	}
}
