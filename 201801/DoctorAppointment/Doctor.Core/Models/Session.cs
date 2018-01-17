using System;

namespace Doctor.Core.Models
{
	public class Session
	{
		public TimeSpan Start { get; set; }
		public TimeSpan End { get; set; }

		public bool IsWorkable()
		{
			return Start > TimeSpan.MinValue && End > TimeSpan.MinValue;
		}
	}
}