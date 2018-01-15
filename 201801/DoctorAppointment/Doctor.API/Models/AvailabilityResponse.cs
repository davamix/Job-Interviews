using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor.API.Models
{
	public class AvailabilityResponse
	{
		public List<Tuple<string, List<TimeSpan>>> Slots { get; set; }

		public AvailabilityResponse()
		{
			Slots = new List<Tuple<string, List<TimeSpan>>>();
		}
	}
}
