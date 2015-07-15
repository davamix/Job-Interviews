using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeIntersect.Contracts.Models
{
	public interface ICube
	{
		IAxis X { get; }
		IAxis Y { get; }
		IAxis Z { get; }

		bool Intersect(ICube cube);
		int IntersectVolume(ICube cube);
	}
}
