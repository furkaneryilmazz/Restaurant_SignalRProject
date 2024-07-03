﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDtos;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutSocialMediaComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _clientFactory;

		public _UILayoutSocialMediaComponentPartial(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _clientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7264/api/SocialMedia");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
