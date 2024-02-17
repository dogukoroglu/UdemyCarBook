using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.CommentDtos;

namespace UdemyCarBook.WebUI.Controllers
{
	[AllowAnonymous]
	public class BlogController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public BlogController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Bloglar";
			ViewBag.v2 = "Yazarlarımızın Blogları";
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7022/api/Blogs/GetAllBlogsWithAuthorList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAllBLogsWithAuthorDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		public async Task<IActionResult> BlogDetail(int id)
		{
			ViewBag.v1 = "Bloglar";
			ViewBag.v2 = "Blog Detayı ve Yorumlar";
			ViewBag.blogid = id;

			var client = _httpClientFactory.CreateClient();
			var responseMessage2 = await client.GetAsync($"https://localhost:7022/api/Comments/CommentCountByBlog?id=" + id);
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			ViewBag.commentCount = jsonData2;
			TempData["commentCount"] = 0;
			return View();
		}

		[HttpGet]
		public PartialViewResult AddComment(int id)
		{
			ViewBag.blogid = id;
			return PartialView();
		}

		[HttpPost]
		public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCommentDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7022/api/Comments/CreateCommentWithMediator", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Default");
			}
			return View();
		}
	}
}
