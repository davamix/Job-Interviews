using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CubeIntersect.Contracts.Models;
using Models = CubeIntersect.Model;
using NUnit.Framework;

namespace CubeIntersect.Test.Model
{
	public class Cube
	{

		[Test]
		public void Cubes_are_overlapped()
		{
			var A = CreateCube(1, 1, 1, 4);
			var B = CreateCube(3, 3, 3, 5);

			Assert.IsTrue(A.Intersect(B));
			Assert.IsTrue(B.Intersect(A));
		}

		[Test]
		public void Cubes_are_not_overlapped()
		{
			var A = CreateCube(1, 1, 1, 4);
			var B = CreateCube(-5, -5, -5, 5);

			Assert.IsFalse(A.Intersect(B));
			Assert.IsFalse(B.Intersect(A));
		}

		[Test]
		public void Volume_of_overlapped_cube()
		{
			var A = CreateCube(1, 1, 1, 4);
			var B = CreateCube(3, 3, 3, 5);

			Assert.AreEqual(A.IntersectVolume(B), 8);
			Assert.AreEqual(B.IntersectVolume(A), 8);
		}

		[Test]
		public void Volume_is_negative_for_not_overlapping_cubes()
		{
			var A = CreateCube(1, 1, 1, 4);
			var B = CreateCube(-5, -5, -5, 5);

			Assert.AreEqual(A.IntersectVolume(B), -1);
			Assert.AreEqual(B.IntersectVolume(A), -1);
		}


		private ICube CreateCube(int x, int y, int z, int size)
		{
			return new Models.Cube(x, y, z, size);
		}
	}
}
