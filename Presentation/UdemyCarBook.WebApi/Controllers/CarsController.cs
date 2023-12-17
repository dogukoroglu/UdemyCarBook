using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly CreateCarCommandHandler _createCarCommandHandler;
		private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
		private readonly GetCarQueryHandler _getCarQueryHandler;
		private readonly UpdateCarCommandHandler _updateCarCommandHandler;
		private readonly RemoveCarCommandHandler _removeCarCommandHandler;

		public CarsController(CreateCarCommandHandler createCarCommandHandler,
			GetCarByIdQueryHandler getCarByIdQueryHandler,
			GetCarQueryHandler getCarQueryHandler,
			UpdateCarCommandHandler updateCarCommandHandler,
			RemoveCarCommandHandler removeCarCommandHandler)
		{
			_createCarCommandHandler = createCarCommandHandler;
			_getCarByIdQueryHandler = getCarByIdQueryHandler;
			_getCarQueryHandler = getCarQueryHandler;
			_updateCarCommandHandler = updateCarCommandHandler;
			_removeCarCommandHandler = removeCarCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> CarList()
		{
			var values = await _getCarQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCar(int id)
		{
			var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateCarCommand command)
		{
			await _createCarCommandHandler.Handle(command);
			return Ok("Araç bilgisi eklendi!");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveCar(int id)
		{
			await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
			return Ok("Araç bilgisi silindi!");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
		{
			await _updateCarCommandHandler.Handle(command);
			return Ok("Araç bilgisi güncellendi!");
		}
	}
}
