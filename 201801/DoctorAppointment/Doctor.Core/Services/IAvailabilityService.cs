using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Doctor.Core.DTOs;
using Doctor.Core.Models;

namespace Doctor.Core.Services
{
	public interface IAvailabilityService
	{
		Task<Availability> GetAvailability(DateTime date);

		Task TakeSlot(SlotDto slot);
	}
}
