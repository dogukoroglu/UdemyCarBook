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
	public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
	{
		private readonly IStatisticRepository _repository;
		public GetBlogCountQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetBlogCount();
			return new GetBlogCountQueryResult
			{
				BlogCount = value
			};
		}
	}
}
