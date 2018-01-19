using System;
using System.Collections.Generic;
using System.Text;
using Doctor.Core.Models;
using Xunit;

namespace UnitTests.Doctor.Core.Models.WorkPeriodTests
{
	public class IsWorkable
	{
		[Fact]
		public void Non_Hours_Stablished_Is_Not_Workable()
		{
			var wp = new WorkPeriod();

			Assert.False(wp.IsWorkable());
		}

		[Fact]
		public void StartHour_Greater_Than_Zero_Is_Workable()
		{
			var wp = new WorkPeriod { StartHour = 1 };

			Assert.True(wp.IsWorkable());
		}

		[Fact]
		public void EndHour_Greater_Than_Zero_Is_Workable()
		{
			var wp = new WorkPeriod { EndHour = 1 };

			Assert.True(wp.IsWorkable());
		}
	}
}
