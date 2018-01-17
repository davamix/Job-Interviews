using System;
using System.Collections.Generic;
using System.Text;

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
	}

	
}
