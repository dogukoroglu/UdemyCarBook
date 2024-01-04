using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
	public class GetCarBrandAndModelByRentPriceDailyMaxQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMaxQuery, GetCarBrandAndModelByRentPriceDailyMaxQueryResult>
	{
		private readonly IStatisticRepository _repository;
		public GetCarBrandAndModelByRentPriceDailyMaxQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarBrandAndModelByRentPriceDailyMaxQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyMaxQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetCarBrandAndModelByRentPriceDailyMax();
			return new GetCarBrandAndModelByRentPriceDailyMaxQueryResult
			{
				CarBrandAndModelByRentPriceDailyMax = value.ToString()
			};
		}
	}
}
