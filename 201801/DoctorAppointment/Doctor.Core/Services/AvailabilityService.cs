using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Doctor.Core.DTOs;
using Doctor.Core.Models;
using Doctor.Core.Network;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Doctor.Core.Services
{
	public class AvailabilityService : IAvailabilityService
	{
		private readonly IHttpClient _apiClient;
		private readonly IOptions<AppSettings> _settings;
		private readonly string _remoteBaseUrl;

		public AvailabilityService(IHttpClient httpClient, IOptions<AppSettings> settings)
		{
			_apiClient = httpClient;
			_settings = settings;

			_remoteBaseUrl = _settings.Value.AvailabilityUrl;
		}


		public async Task<Availability> GetAvailability(DateTime date)
		{
			string validDate = date.ToString("yyyyMMdd");
			var getAvailabilityUrl = _remoteBaseUrl + $"/api/availability/GetAvailability/{validDate}";

			var responseData = await _apiClient.GetStringAsync(getAvailabilityUrl);

			var response = JsonConvert.DeserializeObject<Availability>(responseData, new JsonSerializerSettings{});

			// Check if response is null. 
			// Return null or and empty object? Error object?

			return response;
		}

		public async Task TakeSlot(SlotDto slot)
		{
			var postAvailiabiltyUrl = _remoteBaseUrl + "/api/availability/TakeSlot";

			var response = await _apiClient.PostAsync(postAvailiabiltyUrl, slot);

			response.EnsureSuccessStatusCode();
		}
	}
}
