using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;

namespace UdemyCarBook.Application.Validators.ReviewValidators
{
	public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
	{
		public UpdateReviewValidator()
		{
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz!");
			RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapınız!");
			RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz!");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum alanını boş geçmeyiniz!");
			RuleFor(x => x.Comment).MinimumLength(20).WithMessage("Lütfen yorum alanına en az 20 karakter girişi yapınız!");
		}
	}
}
