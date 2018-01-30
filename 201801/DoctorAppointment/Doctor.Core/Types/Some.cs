using System;

namespace Doctor.Core.Types
{
	/// <summary>
	/// Code from Functional Programming in C#
	/// https://github.com/la-yumba/functional-csharp-code
	/// </summary>

	public struct Some<T>
	{
		internal T Value { get; }

		internal Some(T value)
		{
			if (value == null)
				throw new ArgumentNullException();

			Value = value;
		}
	}
}