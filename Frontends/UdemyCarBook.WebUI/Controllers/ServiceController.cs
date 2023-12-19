using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers
{
	public class ServiceController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
