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
	public class GetCarCountByTransmissionAutoQueryHandler : IRequestHandler<GetCarCountByTransmissionAutoQuery, GetCarCountByTransmissionAutoQueryResult>
	{
		private readonly IStatisticRepository _repository;
		public GetCarCountByTransmissionAutoQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}
		public async Task<GetCarCountByTransmissionAutoQueryResult> Handle(GetCarCountByTransmissionAutoQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetCarCountByTransmissionAuto();
			return new GetCarCountByTransmissionAutoQueryResult
			{
				CarCountByTransmissionAuto = value
			};
		}
	}
}
