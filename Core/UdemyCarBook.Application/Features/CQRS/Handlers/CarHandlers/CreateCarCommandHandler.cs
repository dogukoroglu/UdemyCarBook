using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class CreateCarCommandHandler
	{
		private readonly IRepository<Car> _repository;
		public CreateCarCommandHandler(IRepository<Car> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCarCommand command)
		{
			await _repository.CreateAsync(new Car
			{
				Km = command.Km,
				Luggage = command.Luggage,
				Model = command.Model,
				Seat = command.Seat,
				Transmission = command.Transmission,
				Fuel = command.Fuel,
				CoverImageUrl = command.CoverImageUrl,
				BrandID = command.BrandID,
				BigImageUrl = command.BigImageUrl
			});
		}
	}
}
