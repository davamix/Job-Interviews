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
		public void NonHoursStablishedIsNotWorkable()
		{
			var wp = new WorkPeriod();

			Assert.False(wp.IsWorkable());
		}

		[Fact]
		public void StartHourGreaterThanZeroIsWorkable()
		{
			var wp = new WorkPeriod { StartHour = 1 };

			Assert.True(wp.IsWorkable());
		}

		[Fact]
		public void EndHourGreaterThanZeroIsWorkable()
		{
			var wp = new WorkPeriod { EndHour = 1 };

			Assert.True(wp.IsWorkable());
		}
	}
}
