using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardComponents
{
	public class _AdminDashboardBlogListComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _AdminDashboardBlogListComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7022/api/Blogs/GetAllBlogsWithAuthorList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAllBLogsWithAuthorDto>>(jsonData);
				return View(values.Take(4).ToList());
			}
			return View();
		}
	}
}
