using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand>
	{
		private readonly IRepository<Review> _repository;
		public UpdateReviewHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.ReviewID);
			values.CustomerName = request.CustomerName;
			values.ReviewDate = request.ReviewDate;
			values.CarID = request.CarID;
			values.Comment = request.Comment;
			values.RatingValue = request.RatingValue;
			values.CustomerImage = request.CustomerImage;
			await _repository.UpdateAsync(values);
		}
	}
}
