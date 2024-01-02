using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces.StatisticInterfaces;
using UdemyCarBook.Application.Interfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
	public class GetCarCountByFuelGasolineOrDieselQueryHandler : IRequestHandler<GetCarCountByFuelGasolineOrDieselQuery, GetCarCountByFuelGasolineOrDieselQueryResult>
	{
		private readonly IStatisticRepository _repository;
		public GetCarCountByFuelGasolineOrDieselQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarCountByFuelGasolineOrDieselQueryResult> Handle(GetCarCountByFuelGasolineOrDieselQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetCarCountByFuelGasolineOrDiesel();
			return new GetCarCountByFuelGasolineOrDieselQueryResult
			{
				CarCountByFuelGasolineOrDiesel = value
			};
		}
	}
}
