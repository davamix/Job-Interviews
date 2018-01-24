using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Doctor.Core.DTOs;
using Doctor.Core.Models;
using Doctor.Core.Types;

namespace Doctor.Core.Services
{
	public interface IAvailabilityService
	{
		Task<Either<string, Availability>> GetAvailability(DateTime date);

		Task TakeSlot(SlotDto slot);
	}
}
