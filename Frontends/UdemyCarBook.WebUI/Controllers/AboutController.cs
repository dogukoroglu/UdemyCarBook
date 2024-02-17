using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers
{
	[AllowAnonymous]
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.v1 = "Hakkımızda";
			ViewBag.v2 = "Hakkımızda";
			return View();
		}
	}
}
