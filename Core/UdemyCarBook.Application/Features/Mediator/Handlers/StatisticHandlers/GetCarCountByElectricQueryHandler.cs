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
	public class GetCarCountByElectricQueryHandler : IRequestHandler<GetCarCountByElectricQuery, GetCarCountByElectricQueryResult>
	{
		private readonly IStatisticRepository _repository;
		public GetCarCountByElectricQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarCountByElectricQueryResult> Handle(GetCarCountByElectricQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetCarCountByElectric();
			return new GetCarCountByElectricQueryResult
			{
				CarCountByElectric = value
			};
		}
	}
}
