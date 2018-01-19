using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Doctor.Core.Models
{
	public class WorkingDay
	{
		public WorkPeriod WorkPeriod { get; set; }
		public List<BusySlot> BusySlots { get; set; }
		public string DayName { get; set; }

		[JsonProperty]
		private int StartHour
		{
			get => WorkPeriod.StartHour;
			set => WorkPeriod.StartHour = value;
		}

		[JsonProperty]
		private int EndHour
		{
			get => WorkPeriod.EndHour;
			set => WorkPeriod.EndHour = value;
		}

		[JsonProperty]
		private int LunchStartHour
		{
			get => WorkPeriod.LunchStartHour;
			set => WorkPeriod.LunchStartHour = value;
		}

		[JsonProperty]
		private int LunchEndHour
		{
			get => WorkPeriod.LunchEndHour;
			set => WorkPeriod.LunchEndHour = value;
		}

		public WorkingDay(string dayName)
		{
			WorkPeriod = new WorkPeriod();
			BusySlots = new List<BusySlot>();
			DayName = dayName;
		}

		public IEnumerable<TimeSpan> SplitInSlots(int slotDuration)
		{
			if (!WorkPeriod.IsWorkable()) return Enumerable.Empty<TimeSpan>();
			
			var slots = WorkPeriod.SplitInSlots(slotDuration);

			if (BusySlots.Any())
				return RemoveBusySlots(slots);

			return slots;
		}

		private List<TimeSpan> RemoveBusySlots(IList<TimeSpan> slots)
		{
			var slotsToRemove = new List<TimeSpan>();

			// Convert List<BusySlot> (DateTime values) to List<Interval> (TimeSpan values)
			var busyIntervals = BusySlots.Select(x => new Interval
			                                           {
				                                           Start = new TimeSpan(x.Start.Hour, x.Start.Minute, x.Start.Second),
				                                           End = new TimeSpan(x.End.Hour, x.End.Minute, x.End.Second)
			                                           });
			
			// Compared the slots list with the busy slots list.
			// Overlapped slots are added to the list of slots to be removed
			Parallel.ForEach(slots, x =>
			                        {
				                        if (IsOverlap(x, busyIntervals))
					                        slotsToRemove.Add(x);
			                        });

			// Return a new list of slots without the busy slots.
			return slots.Except(slotsToRemove).ToList();
		}

		private bool IsOverlap(TimeSpan slot, IEnumerable<Interval> intervals)
		{
			return intervals.Any(x => slot >= x.Start && slot < x.End);
		}
		
	}
}
