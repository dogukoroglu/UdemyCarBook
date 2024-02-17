using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UdemyCarBook.Dto.FooterAddressDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]
	[Route("Admin/AdminFooterAddress")]
	public class AdminFooterAddressController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public AdminFooterAddressController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7022/api/FooterAddresses");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[Route("CreateFooterAddress")]
		[HttpGet]
		public IActionResult CreateFooterAddress()
		{
			return View();
		}

		[Route("CreateFooterAddress")]
		[HttpPost]
		public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressDto createFooterAddressDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFooterAddressDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7022/api/FooterAddresses", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminFooterAddress");
			}
			return View();
		}

		[Route("RemoveFooterAddress/{id}")]
		public async Task<IActionResult> RemoveFooterAddress(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7022/api/FooterAddresses/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "AdminFooterAddress");
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateFooterAddress/{id}")]
		public async Task<IActionResult> UpdateFooterAddress(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7022/api/FooterAddresses/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFooterAddressDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		[Route("UpdateFooterAddress/{id}")]
		public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressDto updateFooterAddressDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFooterAddressDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7022/api/FooterAddresses/", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
