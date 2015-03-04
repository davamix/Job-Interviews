namespace TKTManager.Model
{
	using System;

	public class PriceHistory
	{
		public Guid ArticleId { get; set; }
		public double Price { get; set; }
		public DateTime InsertionDateTime { get; set; }
	}
}
