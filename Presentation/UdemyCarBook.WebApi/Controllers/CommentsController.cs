using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly IGenericRepository<Comment> _commentsRepository;
		public CommentsController(IGenericRepository<Comment> commentsRepository)
		{
			_commentsRepository = commentsRepository;
		}

		[HttpGet]
		public IActionResult CommentList()
		{
			var values = _commentsRepository.GetAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateComment(Comment comment)
		{
			_commentsRepository.Create(comment);
			return Ok("Yorum başarılı bir şekilde eklendi!");
		}

		[HttpDelete]
		public IActionResult RemoveComment(int id)
		{
			var value = _commentsRepository.GetById(id);
			_commentsRepository.Remove(value);
			return Ok("Yorum başarılı bir şekilde silindi!");
		}

		[HttpPut]
		public IActionResult UpdateComment(Comment comment)
		{
			_commentsRepository.Update(comment);
			return Ok("Yorum başarılı bir şekilde güncellendi!");
		}

		[HttpGet("{id}")]
		public IActionResult GetCommentByID(int id)
		{
			var value = _commentsRepository.GetById(id);
			return Ok(value);
		}
	}
}
