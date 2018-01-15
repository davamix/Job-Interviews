using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Doctor.Core.Models
{
	internal class Session
	{
		public TimeSpan Start { get; set; }
		public TimeSpan End { get; set; }

		public bool IsWorkable()
		{
			return Start > TimeSpan.MinValue && End > TimeSpan.MinValue;
		}
	}

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

		public bool IsWorkigDay()
		{
			return (WorkPeriod.StartHour > 0 && WorkPeriod.EndHour > 0) ||
				   (WorkPeriod.LunchStartHour > 0 && WorkPeriod.LunchEndHour > 0);
		}

		public List<TimeSpan> SplitInTimeSpan(int slotDuration)
		{
			var slots = new List<TimeSpan>();
			var (morning, afternoon) = GetSessions();

			if (morning.IsWorkable())
				slots.AddRange(Split(morning, slotDuration));

			if (afternoon.IsWorkable())
				slots.AddRange(Split(afternoon, slotDuration));

			if (BusySlots.Any())
				slots = RemoveBusySlots(slots);

			return slots;
		}

		private (Session morning, Session afternoon) GetSessions()
		{
			var morning = new Session();
			var afternoon = new Session();

			// Split shift
			if (StartHour < LunchStartHour && EndHour > LunchEndHour)
			{
				morning.Start = new TimeSpan(StartHour, 0, 0);
				morning.End = new TimeSpan(LunchStartHour, 0, 0);
				afternoon.Start = new TimeSpan(LunchEndHour, 0, 0);
				afternoon.End = new TimeSpan(EndHour, 0, 0);
			}

			// Only morning
			if (EndHour < LunchStartHour)
			{
				morning.Start = new TimeSpan(StartHour, 0, 0);
				morning.End = new TimeSpan(EndHour, 0, 0);
			}

			// Only Afternoon
			if (StartHour > LunchEndHour)
			{
				afternoon.Start = new TimeSpan(StartHour, 0, 0);
				afternoon.End = new TimeSpan(EndHour, 0, 0);
			}

			return (morning, afternoon);
		}

		private List<TimeSpan> Split(Session session, int slotDuration)
		{
			var slots = new List<TimeSpan>();
			var workingMinutes = (session.End - session.Start).TotalMinutes;

			var startSlot = session.Start;

			for (var x = 0; x < workingMinutes; x += slotDuration)
			{
				var newSlot = new TimeSpan(0, x, 0);
				slots.Add(startSlot.Add(newSlot));
			}

			return slots;
		}

		private List<TimeSpan> RemoveBusySlots(IList<TimeSpan> slots)
		{
			var busyIntervals = BusySlots.Select(x => new Tuple<TimeSpan, TimeSpan>(new TimeSpan(x.Start.Hour, x.Start.Minute, x.Start.Second),
																					new TimeSpan(x.End.Hour, x.End.Minute, x.End.Second))).ToList();

			var slotsToRemove = new List<TimeSpan>();

			Parallel.ForEach(slots, x =>
			{
				if (IsOverlap(x, busyIntervals))
					slotsToRemove.Add(x);
			});

			return slots.Except(slotsToRemove).ToList();
		}

		private bool IsOverlap(TimeSpan slot, IEnumerable<Tuple<TimeSpan, TimeSpan>> intervals)
		{
			return intervals.Any(x => slot >= x.Item1 && slot < x.Item2);
		}
	}
}
