using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class CreateTestimonialCommandHandler : IRequestHandler<CreateLocationCommand>
	{
		private readonly IRepository<Location> _repository;
		public CreateTestimonialCommandHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Location
			{
				Name = request.Name
			});
		}
	}
}
