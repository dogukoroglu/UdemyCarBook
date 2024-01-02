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
	public class GetBlogTitleByMaxBlogCommentQueryHandler : IRequestHandler<GetBlogTitleByMaxBlogCommentQuery, GetBlogTitleByMaxBlogCommentQueryResult>
	{
		private readonly IStatisticRepository _repository;
		public GetBlogTitleByMaxBlogCommentQueryHandler(IStatisticRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetBlogTitleByMaxBlogCommentQueryResult> Handle(GetBlogTitleByMaxBlogCommentQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetBlogTitleByMaxBlogComment();
			return new GetBlogTitleByMaxBlogCommentQueryResult
			{
				BlogTitleByMaxBlogComment = value.ToString(),
			};
		}
	}
}
