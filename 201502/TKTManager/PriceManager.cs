namespace TKTManager
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;

	public class PriceManager : IPriceManager
    {
		private ICatalogManager _catalogManager;

		public PriceManager(ICatalogManager catalogManager)
		{
			_catalogManager = catalogManager;
		}

		public void AddArticle(string name, double price, DateTime insertionDateTime)
		{
			_catalogManager.Add(name, price, insertionDateTime);
		}

		public bool AddPromotion(string articleName, double discount, DateTime startDate, int durationDays)
		{
			return _catalogManager.AddPromotion(articleName, discount, startDate, durationDays);
		}

		public double GetPrice(string name, DateTime date)
		{
			return _catalogManager.GetPrice(name, date);
		}

		public IEnumerable<string> GetArticleNames()
		{
			return _catalogManager.GetArticles().Select(x => x.Name);
		}

		public void SetChristmasPeriod(DateTime startDate, DateTime endDate)
		{
			_catalogManager.SetChristmasPeriod(startDate, endDate);
		}

		public void SetClearancePeriod(DateTime startDate, int DaysDuration)
		{
			_catalogManager.SetClearancePeriod(startDate, DaysDuration);
		}
    }
}
