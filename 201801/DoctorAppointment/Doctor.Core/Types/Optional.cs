using System;

namespace Doctor.Core.Types
{
	/// <summary>
	/// Code from Functional Programming in C#
	/// https://github.com/la-yumba/functional-csharp-code
	/// </summary>

	public struct Optional<T> :IEquatable<None>, IEquatable<Optional<T>>
	{
		public static Optional<T> Some<T>(T value) => new Some<T>(value); // wrap the given value into a Some
		public static None None => None.Default;

		private readonly T _value;
		readonly bool _isSome;
		bool isNone => !_isSome;

		private Optional(T value)
		{
			if (value == null)
				throw new ArgumentNullException();

			_isSome = true;
			_value = value;
		}

		public static implicit operator Optional<T>(None _) => new Optional<T>();
		public static implicit operator Optional<T>(Some<T> some) => new Optional<T>(some.Value);
		public static implicit operator Optional<T>(T value) => value == null ? None : Some(value);

		public R Match<R>(Func<R> None, Func<T, R> Some)=> _isSome ? Some(_value) : None();

		public bool Equals(None other) => _isSome;

		public bool Equals(Optional<T> other) => _isSome == other._isSome
		                                         && (isNone || _value.Equals(other._value));

		public static bool operator ==(Optional<T> @this, Optional<T> other) => @this.Equals(other);
		public static bool operator !=(Optional<T> @this, Optional<T> other) => !(@this == other);

		public override string ToString() => _isSome ? $"Some({_value})" : "None";
	}
}