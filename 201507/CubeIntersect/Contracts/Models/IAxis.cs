using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeIntersect.Contracts.Models
{
	public interface IAxis
	{
		int Start { get;}
		int End { get;}

		bool Intersect(IAxis axis);
		int IntersectSize(IAxis axis);
	}
}
