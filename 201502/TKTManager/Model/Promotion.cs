namespace TKTManager.Model
{
	using System;

	public class Promotion
	{
		public Guid ArticleId { get; set; }
		public double Discount { get; set; }
		public DateTime StartDate { get; set; }
		public int Duration { get; set; }
	}
}
