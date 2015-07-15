using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CubeIntersect.Contracts.Models;
using Models = CubeIntersect.Model;
using NUnit.Framework;

namespace CubeIntersect.Test.Model
{
	public class Axis
	{
		[Test]
		public void Axes_Are_Overlapped()
		{
			var A = CreateAxis(1, 5);
			var B = CreateAxis(3, 8);

			Assert.IsTrue(A.Intersect(B));
			Assert.IsTrue(B.Intersect(A));
		}

		[Test]
		public void Axes_Are_Not_Overlapped()
		{
			var A = CreateAxis(1, 5);
			var B = CreateAxis(6, 10);

			Assert.IsFalse(A.Intersect(B));
			Assert.IsFalse(B.Intersect(A));
		}

		[Test]
		public void Axes_Has_IntersectSize_Of_Two()
		{
			var A = CreateAxis(1, 5);
			var B = CreateAxis(3, 8);

			Assert.AreEqual(A.IntersectSize(B), 2);
			Assert.AreEqual(B.IntersectSize(A), 2);
		}

		[Test]
		public void IntersectSize_is_negative_for_not_overlapped_axes()
		{
			var A = CreateAxis(1, 5);
			var B = CreateAxis(6, 10);

			Assert.AreEqual(A.IntersectSize(B), -1);
			Assert.AreEqual(B.IntersectSize(A), -1);
		}

		private IAxis CreateAxis(int start, int end)
		{
			return new Models.Axis(start, end);
		}
	}
}
