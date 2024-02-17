using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Dto.LoginDtos;

namespace UdemyCarBook.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public LoginController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(CreateLoginDto createLoginDto)
		{
			var client = _httpClientFactory.CreateClient();
			return View();
		}
	}
}
