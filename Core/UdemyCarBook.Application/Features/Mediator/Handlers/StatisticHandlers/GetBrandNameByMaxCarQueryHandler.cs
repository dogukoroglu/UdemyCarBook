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
	public class GetBrandNameByMaxCarQueryHandler : IRequestHandler<GetBrandNameByMaxCarQuery, GetBrandNameByMaxCarQueryResult>
	{
		private readonly IStatisticRepository _repository;
		public GetBrandNameByMaxCarQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}
		public async Task<GetBrandNameByMaxCarQueryResult> Handle(GetBrandNameByMaxCarQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetBrandNameByMaxCar();
			return new GetBrandNameByMaxCarQueryResult
			{
				BrandNameByMaxCar = value.ToString(),
			};
		}
	}
}
