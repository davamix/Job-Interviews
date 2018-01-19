using System;
using System.Collections.Generic;

namespace Doctor.Core.Models
{
	public class Interval
	{
		public TimeSpan Start { get; set; }
		public TimeSpan End { get; set; }

		public List<TimeSpan> Split(int slotDuration)
		{
			var slots = new List<TimeSpan>();
			var workingMinutes = (End - Start).TotalMinutes;

			var startSlot = Start;

			for (var x = 0; x < workingMinutes; x += slotDuration)
			{
				var newSlot = new TimeSpan(0, x, 0);
				slots.Add(startSlot.Add(newSlot));
			}

			return slots;
		}
	}
}