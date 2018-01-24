using System;
using System.Collections.Generic;
using System.Text;

namespace Doctor.Core.Types
{
	/// <summary>
	/// Class to wrap the response from a function
	/// </summary>
	/// <typeparam name="L">Wraps the value of type L, capturing de details about the error</typeparam>
	/// <typeparam name="R">Wraps the value of type R, representing the successful result</typeparam>
	public class Either<L, R>
    {
		internal L Left { get; }
		internal R Right { get; }

		private bool _isRight { get; }
	    private bool _isLeft => !_isRight;

	    internal Either(L left)
	    {
		    _isRight = false;
			Left = left;
		    Right = default(R);
	    }

	    internal Either(R right)
	    {
		    _isRight = true;
		    Right = right;
		    Left = default(L);
	    }

		public static implicit operator Either<L,R>(L left) => new Either<L, R>(left);
		public static implicit operator Either<L, R>(R right) => new Either<L, R>(right);

	    public TR Match<TR>(Func<L, TR> Left, Func<R, TR> Right) => _isLeft ? Left(this.Left) : Right(this.Right);
    }
}
