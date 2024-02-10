using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.StatisticDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardComponents
{
	public class _AdminDashboardStatisticComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _AdminDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			Random random = new Random();
			var client = _httpClientFactory.CreateClient();

			#region İstatistik1
			var responseMessage = await client.GetAsync("https://localhost:7022/api/Statistics/GetCarCount");
			if (responseMessage.IsSuccessStatusCode)
			{
				int carCountRandom = random.Next(0, 101);
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
				ViewBag.carCount = values.carCount;
				ViewBag.random1 = carCountRandom;
			}
			#endregion

			#region İstatistik2
			var responseMessage2 = await client.GetAsync("https://localhost:7022/api/Statistics/GetLocationCount");
			if (responseMessage2.IsSuccessStatusCode)
			{
				int locationCountRandom = random.Next(0, 101);
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var values2 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
				ViewBag.locationCount = values2.locationCount;
				ViewBag.random2 = locationCountRandom;
			}
			#endregion

			#region İstatistik3
			var responseMessage3 = await client.GetAsync("https://localhost:7022/api/Statistics/GetBrandCount");
			if (responseMessage3.IsSuccessStatusCode)
			{
				int brandCountRandom = random.Next(0, 101);
				var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
				var values3 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData3);
				ViewBag.brandCount = values3.brandCount;
				ViewBag.brandCountRandom = brandCountRandom;
			}
			#endregion

			#region İstatistik4
			var responseMessage4 = await client.GetAsync("https://localhost:7022/api/Statistics/GetAvgRentPriceForDaily");
			if (responseMessage4.IsSuccessStatusCode)
			{
				int avgPriceForDailyRandom = random.Next(0, 101);
				var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
				var values4 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData4);
				ViewBag.avgPriceForDaily = values4.avgPriceForDaily.ToString("0.00");
				ViewBag.avgPriceForDailyRandom = avgPriceForDailyRandom;
			}
			#endregion


			return View();
		}

	}
}
