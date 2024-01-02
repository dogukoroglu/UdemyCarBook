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
	public class GetCarBrandAndModelByRentPriceDailyMinQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMinQuery, GetCarBrandAndModelByRentPriceDailyMinQueryResult>
	{
		private readonly IStatisticRepository _repository;
		public GetCarBrandAndModelByRentPriceDailyMinQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarBrandAndModelByRentPriceDailyMinQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyMinQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetCarCountByElectric();
			return new GetCarBrandAndModelByRentPriceDailyMinQueryResult
			{
				CarBrandAndModelByRentPriceDailyMin = value.ToString()
			};
		}
	}
}
