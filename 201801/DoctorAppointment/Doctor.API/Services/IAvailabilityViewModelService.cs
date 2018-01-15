using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctor.API.Models;

namespace Doctor.API.Services
{
	public interface IAvailabilityViewModelService
	{
		Task<AvailabilityResponse> GetAvailability(DateTime date);

		Task TakeSlot(SlotRequest slot);
	}
}
