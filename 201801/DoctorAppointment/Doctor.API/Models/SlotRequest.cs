using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor.API.Models
{
	public class SlotRequest
	{
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public Patient Patient { get; set; }
		public string Comments { get; set; }

		public SlotRequest()
		{
			Patient = new Patient();
		}
	}

	public class Patient
	{
		public string Name { get; set; }
		public string SecondName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}
}
