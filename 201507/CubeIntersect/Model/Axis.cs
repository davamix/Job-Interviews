using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CubeIntersect.Contracts.Models;

namespace CubeIntersect.Model
{
	public class Axis : IAxis
	{
		public int Start { get; private set; }
		public int End { get; private set; }

		public Axis(int start, int end)
		{
			this.Start = start;
			this.End = end;
		}

		/// <summary>
		/// Check if current axis is overlapping with other
		/// </summary>
		/// <param name="axis"></param>
		/// <returns>TRUE if overlap</returns>
		public bool Intersect(IAxis axis)
		{
			return IntersectSize(axis) >= 0;
		}

		public int IntersectSize(IAxis axis)
		{
			if (this.Start <= axis.Start && axis.Start <= this.End)
				return this.End - axis.Start;

			if (axis.Start <= this.Start && this.Start <= axis.End)
				return axis.End - this.Start;

			return -1;
		}
	}
}
