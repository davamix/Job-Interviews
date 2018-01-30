using Doctor.Core;
using Microsoft.Extensions.Options;

namespace UnitTests.Mocks
{
	public class OptionsMock : IOptions<AppSettings>
	{
		public AppSettings Value { get; }

		public OptionsMock()
		{
			Value = new AppSettings();
		}
	}
}