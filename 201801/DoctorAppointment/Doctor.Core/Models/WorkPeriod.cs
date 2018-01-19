using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.Core.Models
{
	public class WorkPeriod
	{
		public int StartHour { get; set; }
		public int EndHour { get; set; }
		public int LunchStartHour { get; set; }
		public int LunchEndHour { get; set; }

		public bool IsWorkable()
		{
			return StartHour != 0 || EndHour != 0;
		}

		public List<TimeSpan> SplitInSlots(int slotDuration)
		{
			var slots = new List<TimeSpan>();

			// Split shift
			if (StartHour < LunchStartHour && EndHour>LunchEndHour)
			{
				var interval1 = new Interval {Start = new TimeSpan(StartHour,0,0), End = new TimeSpan(LunchStartHour, 0,0)};
				var interval2 = new Interval {Start = new TimeSpan(LunchEndHour,0,0), End = new TimeSpan(EndHour,0,0)};

				slots.AddRange(interval1.Split(slotDuration));
				slots.AddRange(interval2.Split(slotDuration));
			}
			// Morning or Afternoon
			else
			{
				var interval = new Interval { Start = new TimeSpan(StartHour, 0, 0), End = new TimeSpan(EndHour, 0, 0) };

				slots.AddRange(interval.Split(slotDuration));
			}

			return slots;
		}
	}
}
