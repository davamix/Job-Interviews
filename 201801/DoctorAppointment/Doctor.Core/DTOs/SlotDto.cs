using System;
using System.Collections.Generic;
using System.Text;

namespace Doctor.Core.DTOs
{
	public class SlotDto
	{
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public PatientDto Patient { get; set; }
		public string Comments { get; set; }

		public SlotDto()
		{
			Patient = new PatientDto();
		}
	}

	public class PatientDto
	{
		public string Name { get; set; }
		public string SecondName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}
}
