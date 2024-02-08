﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
	public class CreateCommentHandler : IRequestHandler<CreateCommentCommand>
	{
		private readonly IRepository<Comment> _repository;
		public CreateCommentHandler(IRepository<Comment> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Comment
			{
				Description = request.Description,
				Name = request.Name,
				BlogID = request.BlogID,
				CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
				Email = request.Email
			});
		}
	}
}