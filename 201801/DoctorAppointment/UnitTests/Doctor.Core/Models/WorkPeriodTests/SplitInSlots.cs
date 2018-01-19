using System;
using System.Collections.Generic;
using System.Text;
using Doctor.Core.Models;
using Xunit;

namespace UnitTests.Doctor.Core.Models.WorkPeriodTests
{
    public class SplitInSlots
    {
	    private int _slotDuration => 60; // minutes

	    [Fact]
	    public void LunchTime_Splits_StartTime_And_EndTime()
	    {
		    var wp = new WorkPeriod
		             {
			             StartHour = 10,
			             EndHour = 18,
			             LunchStartHour = 13,
			             LunchEndHour = 14
		             };

		    var result = wp.SplitInSlots(_slotDuration);

			Assert.Equal(7, result.Count);
	    }

	    [Fact]
	    public void StartTime_And_EndTime_Before_LunchTime()
	    {
		    var wp = new WorkPeriod
		             {
			             StartHour = 10,
			             EndHour = 12,
			             LunchStartHour = 13,
			             LunchEndHour = 14
		             };

		    var result = wp.SplitInSlots(_slotDuration);

			Assert.Equal(2, result.Count);
	    }
		
	    [Fact]
	    public void StartTime_And_EndTime_After_LunchTime()
	    {
		    var wp = new WorkPeriod
		             {
			             StartHour = 15,
			             EndHour = 18,
			             LunchStartHour = 13,
			             LunchEndHour = 14
		             };

		    var result = wp.SplitInSlots(_slotDuration);

			Assert.Equal(3, result.Count);
	    }

	    [Fact]
	    public void StartTime_And_EndTime_Before_Lunch_Time_Without_LaunchTime_Specified()
	    {
		    var wp = new WorkPeriod
		             {
			             StartHour = 10,
			             EndHour = 12
		             };

		    var result = wp.SplitInSlots(_slotDuration);

		    Assert.Equal(2, result.Count);
	    }

	    [Fact]
	    public void StartTime_And_EndTime_After_Lunch_Time_Without_LaunchTime_Specified()
	    {
		    var wp = new WorkPeriod
		             {
			             StartHour = 15,
			             EndHour = 18
		             };

		    var result = wp.SplitInSlots(_slotDuration);

		    Assert.Equal(3, result.Count);
	    }
	}
}
