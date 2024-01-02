using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
	public class GetAvgRentPriceForWeeklyQueryHandler : IRequestHandler<GetAvgRentPriceForWeeklyQuery, GetAvgRentPriceForWeeklyQueryResult>
	{
		private readonly IStatisticRepository _repository;
		public GetAvgRentPriceForWeeklyQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetAvgRentPriceForWeeklyQueryResult> Handle(GetAvgRentPriceForWeeklyQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetAvgRentPriceForWeekly();
			return new GetAvgRentPriceForWeeklyQueryResult
			{
				AvgRentPriceForWeekly = value
			};
		}
	}
}
