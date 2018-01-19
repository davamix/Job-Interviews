using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Doctor.Core.Models;
using Xunit;

namespace UnitTests.Doctor.Core.Models.WorkingDayTests
{
    public class SplitInSlots
    {
	    private int _slotDuration => 60; // minutes

	    [Fact]
	    public void A_WorkPeriod_Non_Workable_Return_An_Empty_List()
	    {
		    var wd = new WorkingDay("day");

		    var result = wd.SplitInSlots(_slotDuration);

			Assert.Empty(result);
	    }

	    [Fact]
	    public void Split_The_WorkPeriod_With_Slot_Duration()
	    {
		    var wp = new WorkPeriod
		             {
			             StartHour = 10,
			             EndHour = 18,
			             LunchStartHour = 13,
			             LunchEndHour = 14
		             };

		    var wd = new WorkingDay("day") {WorkPeriod = wp};
		    
		    var result = wd.SplitInSlots(_slotDuration);

		    Assert.Equal(7, result.Count());
		}

	    [Fact]
	    public void Remove_Slots_Overlapped()
	    {
		    var busySlots = new List<BusySlot>
		                    {
			                    new BusySlot {Start = new DateTime(1, 1, 1, 11, 0, 0), End = new DateTime(1, 1, 1, 12, 0, 0)},
			                    new BusySlot {Start = new DateTime(1, 1, 1, 16, 0, 0), End = new DateTime(1, 1, 1, 17, 0, 0)}
		                    };
		    var wp = new WorkPeriod
		             {
			             StartHour = 10,
			             EndHour = 18,
			             LunchStartHour = 13,
			             LunchEndHour = 14
		             };

		    var wd = new WorkingDay("day")
		             {
			             WorkPeriod = wp,
						 BusySlots = busySlots
		             };

		    var result = wd.SplitInSlots(_slotDuration);

		    Assert.Equal(5, result.Count());
		}
    }
}
