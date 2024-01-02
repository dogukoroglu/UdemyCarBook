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
	public class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResult>
	{
		private readonly IStatisticRepository _repository;
		public GetAuthorCountQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetAuthorCountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetAuthorCount();
			return new GetAuthorCountQueryResult
			{
				AuthorCount = value
			};
		}
	}
}
