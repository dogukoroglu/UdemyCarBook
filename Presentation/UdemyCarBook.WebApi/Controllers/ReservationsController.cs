using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;
namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationsController : ControllerBase
	{
		private readonly IMediator _mediator;
		public ReservationsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		//[HttpGet]
		//public async Task<IActionResult> ReservationList()
		//{
		//	var values = await _mediator.Send(new GetReservationQuery());
		//	return Ok(values);
		//}

		//[HttpGet("{id}")]
		//public async Task<IActionResult> GetReservation(int id)
		//{
		//	var value = await _mediator.Send(new GetReservationByIdQuery(id));
		//	return Ok(value);
		//}

		[HttpPost]
		public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
		{
			await _mediator.Send(command);
			return Ok("Rezervasyon başarıyla eklendi!");
		}

		//[HttpDelete("{id}")]
		//public async Task<IActionResult> RemoveReservation(int id)
		//{
		//	await _mediator.Send(new RemoveReservationCommand(id));
		//	return Ok("Referans başarıyla silindi!");
		//}

		//[HttpPut]
		//public async Task<IActionResult> UpdateReservation(UpdateReservationCommand command)
		//{
		//	await _mediator.Send(command);
		//	return Ok("Referans başarıyla güncellendi!");
		//}
	}
}
