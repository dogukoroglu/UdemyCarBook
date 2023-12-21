﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.CategoryDtos;
namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
	public class _BlogDetailsRecentBlogsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _BlogDetailsRecentBlogsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7022/api/Blogs/GetLast3BlogsWithAuthorsList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthors>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
