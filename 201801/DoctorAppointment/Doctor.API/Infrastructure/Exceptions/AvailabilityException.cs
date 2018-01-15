using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor.API.Infrastructure.Exceptions
{
	public class AvailabilityException : Exception
	{
		public AvailabilityException() { }

		public AvailabilityException(string message)
			: base(message) { }

		public AvailabilityException(string message, Exception innerException)
			: base(message, innerException) { }
	}
}
