﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
	public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
	{
		private readonly IRepository<Reservation> _repository;
		public CreateReservationCommandHandler(IRepository<Reservation> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Reservation
			{
				Name = request.Name,
				Surname = request.Surname,
				Age = request.Age,
				Description = request.Description,
				CarID = request.CarID,
				DriverLicenseYear = request.DriverLicenseYear,
				DropOffLocationID = request.DropOffLocationID,
				Email = request.Email,
				PhoneNumber = request.PhoneNumber,
				PickUpLocationID = request.PickUpLocationID,
				Status = "Rezervasyon Alındı"
			});
		}
	}
}
