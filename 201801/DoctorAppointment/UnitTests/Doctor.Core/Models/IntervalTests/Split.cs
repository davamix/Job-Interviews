using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Doctor.Core.Models;
using Xunit;

namespace UnitTests.Doctor.Core.Models.IntervalTests
{
	public class Split
	{
		[Fact]
		public void Split_Time_In_60_Minutes_Slot()
		{
			var slotDuration = 60;
			var expectedList = new List<TimeSpan>
							   {
								   new TimeSpan(1, 0, 0),
								   new TimeSpan(2, 0, 0),
								   new TimeSpan(3, 0, 0)
							   };
			var interval = new Interval { Start = new TimeSpan(1, 0, 0), End = new TimeSpan(4, 0, 0) };

			var result = interval.Split(slotDuration);

			Assert.Equal(expectedList, result, new TimeSpanComparer());
		}

		[Fact]
		public void Split_Time_In_10_Minutes_Slot()
		{
			var slotDuration = 10;
			var expectedList = new List<TimeSpan>
							   {
								   new TimeSpan(1, 0, 0),
								   new TimeSpan(1, 10, 0),
								   new TimeSpan(1, 20, 0),
								   new TimeSpan(1, 30, 0),
								   new TimeSpan(1, 40, 0),
								   new TimeSpan(1, 50, 0),
								   new TimeSpan(2, 0, 0),
								   new TimeSpan(2, 10, 0),
								   new TimeSpan(2, 20, 0),
								   new TimeSpan(2, 30, 0),
								   new TimeSpan(2, 40, 0),
								   new TimeSpan(2, 50, 0)
							   };
			var interval = new Interval { Start = new TimeSpan(1, 0, 0), End = new TimeSpan(3, 0, 0) };

			var result = interval.Split(slotDuration);

			Assert.Equal(expectedList, result, new TimeSpanComparer());
		}
	}

	internal class TimeSpanComparer : IEqualityComparer<TimeSpan>
	{
		public bool Equals(TimeSpan x, TimeSpan y)
		{
			return x.CompareTo(y) == 0;
		}

		public int GetHashCode(TimeSpan obj)
		{
			throw new NotImplementedException();
		}
	}
}
