using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers
{
	[AllowAnonymous]
	public class ServiceController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.v1 = "Hizmetler";
			ViewBag.v2 = "Hizmetlerimiz";
			return View();
		}
	}
}
