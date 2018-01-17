using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Doctor.API.Models;
using Doctor.Core.DTOs;
using Doctor.Core.Models;
using Doctor.Core.Services;

namespace Doctor.API.Services
{
	public class AvailabilityViewModelService : IAvailabilityViewModelService
	{
		private readonly IAvailabilityService _service;
		private readonly IMapper _mapper;

		public AvailabilityViewModelService(IAvailabilityService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		public async Task<AvailabilityResponse> GetAvailability(DateTime date)
		{
			var availability = await _service.GetAvailability(date);

			var response = GetAvailableSlots(availability);

			return response;
		}

		public Task TakeSlot(SlotRequest slot)
		{
			var dto = _mapper.Map<SlotDto>(slot);

			return _service.TakeSlot(dto);
		}

		private AvailabilityResponse GetAvailableSlots(Availability availability)
		{
			var response = new AvailabilityResponse();

			foreach (var wd in availability.WorkingsDays)
			{
				if (wd.WorkPeriod.IsWorkable())
				{
					var day = new Tuple<string, List<TimeSpan>>(wd.DayName, wd.SplitInTimeSpan(availability.SlotDurationMinutes));
					response.Slots.Add(day);
				}
			}

			return response;
		}
	}
}
