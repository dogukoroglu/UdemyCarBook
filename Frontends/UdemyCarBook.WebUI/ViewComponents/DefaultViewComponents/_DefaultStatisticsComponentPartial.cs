using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using UdemyCarBook.Dto.StatisticDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents
{
	public class _DefaultStatisticsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			#region İstatistik1
			var responseMessage = await client.GetAsync("https://localhost:7022/api/Statistics/GetCarCount");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
				ViewBag.carCount = values.carCount;
			}
			#endregion

			#region İstatistik2
			var responseMessage2 = await client.GetAsync("https://localhost:7022/api/Statistics/GetLocationCount");
			if (responseMessage2.IsSuccessStatusCode)
			{
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var values2 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
				ViewBag.locationCount = values2.locationCount;
			}
			#endregion

			#region İstatistik3
			var responseMessage3 = await client.GetAsync("https://localhost:7022/api/Statistics/GetBrandCount");
			if (responseMessage3.IsSuccessStatusCode)
			{
				var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
				var values5 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData3);
				ViewBag.brandCount = values5.brandCount;
			}
			#endregion

			#region İstatistik4
			var responseMessage4 = await client.GetAsync("https://localhost:7022/api/Statistics/GetCarCountByElectric");
			if (responseMessage4.IsSuccessStatusCode)
			{
				var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
				var values4 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData4);
				ViewBag.carCountByElectric = values4.carCountByElectric;
			}
			#endregion

			return View();
		}
	}
}
