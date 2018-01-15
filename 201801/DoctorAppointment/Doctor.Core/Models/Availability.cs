using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Doctor.Core.Models
{
	public class Availability
	{
		public Facility Facility { get; set; }
		public int SlotDurationMinutes { get; set; }
		public readonly List<WorkingDay> WorkingsDays;

		[JsonProperty]
		private WorkingDay Monday { get; set; }
		[JsonProperty]
		private WorkingDay Tuesday { get; set; }
		[JsonProperty]
		private WorkingDay Wednesday { get; set; }
		[JsonProperty]
		private WorkingDay Thursday { get; set; }
		[JsonProperty]
		private WorkingDay Friday { get; set; }
		[JsonProperty]
		private WorkingDay Saturday { get; set; }
		[JsonProperty]
		private WorkingDay Sunday { get; set; }

		public Availability()
		{
			Facility = new Facility();
			Monday = new WorkingDay("Monday");
			Tuesday = new WorkingDay("Tuesday");
			Wednesday = new WorkingDay("Wednesday");
			Thursday = new WorkingDay("Thursday");
			Friday = new WorkingDay("Friday");
			Saturday = new WorkingDay("Saturday");
			Sunday = new WorkingDay("Sunday");

			WorkingsDays = new List<WorkingDay> { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
		}
	}
}
