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
	public class GetBrandCountQueryHandler : IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
	{
		private readonly IStatisticRepository _repository;
		public GetBrandCountQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetBrandCount();
			return new GetBrandCountQueryResult
			{
				BrandCount = value
			};
		}
	}
}
