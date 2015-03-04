namespace TKTManager.Contracts
{
	using System;
	using System.Collections.Generic;
	using Model;

	public interface ICatalogManager
	{
		void Add(string name, double price, DateTime insertionDateTime);
		IEnumerable<Article> GetArticles();
		double GetPrice(string name, DateTime dateTime);
		bool AddPromotion(string articleName, double discount, DateTime startDate, int durationDays);
		void SetChristmasPeriod(DateTime startDate, DateTime endDate);
		void SetClearancePeriod(DateTime startDate, int DaysDuration);
	}
}
