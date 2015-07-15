using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CubeIntersect.Contracts.Models;

namespace CubeIntersect.Model
{
	public class Cube : ICube
	{
		public IAxis X { get; private set; }
		public IAxis Y { get; private set; }
		public IAxis Z { get; private set; }

		public Cube(int x, int y, int z, int size)
		{
			this.X = new Axis(x, x + size);
			this.Y = new Axis(y, x + size);
			this.Z = new Axis(z, x + size);
		}

		public bool Intersect(ICube cube)
		{
			return
				this.X.Intersect(cube.X) &&
				this.Y.Intersect(cube.Y) &&
				this.Z.Intersect(cube.Z);
		}

		public int IntersectVolume(ICube cube)
		{
			return
				this.X.IntersectSize(cube.X)*
				this.Y.IntersectSize(cube.Y)*
				this.Z.IntersectSize(cube.Z);
		}
	}
}
