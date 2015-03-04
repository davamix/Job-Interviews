namespace TKTManager
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	using Model;

	public class CatalogManager : ICatalogManager
	{
		private List<Article> _articles;
		private List<PriceHistory> _priceHistory;
		private List<Promotion> _promotions;
		private List<Promotion> _specialPromotions;

		public CatalogManager()
		{
			_articles = new List<Article>();
			_priceHistory = new List<PriceHistory>();
			_promotions = new List<Promotion>();
			_specialPromotions = new List<Promotion>();
		}

		public void Add(string name, double price, DateTime insertionDateTime)
		{
			if (IsArticleNameInCollection(name))
				throw new ArgumentException("The article is added in collection");

			var article = AddArticle(name);

			AddPriceHistory(price, insertionDateTime, article.Id);
		}

		public IEnumerable<Article> GetArticles()
		{
			return _articles;
		}

		public double GetPrice(string name, DateTime dateTime)
		{
			if (!IsArticleNameInCollection(name))
				throw new Exception(string.Format("Article {0} doesn't exist", name));

			var article = _articles.First(x => x.Name.Equals(name));

			var priceHistory = _priceHistory.FirstOrDefault(x => x.ArticleId == article.Id && x.InsertionDateTime.Equals(dateTime));

			if (priceHistory != null)
			{
				var price = priceHistory.Price;

				// Search for active promotions
				var activePromotions = GetActivePromotions(article, priceHistory.InsertionDateTime);

				if (activePromotions.Any())
					price = ApplyPromotion(activePromotions, priceHistory.Price);

				return price;
			}

			throw new Exception(string.Format("Article {0} doesn't exist", name));
		}

		// Interpreto que el valor de retorno devuelve False si el artículo no existe, por lo que no se pude aplicar la promoción.
		public bool AddPromotion(string articleName, double discount, DateTime startDate, int durationDays)
		{
			if (!IsArticleNameInCollection(articleName))
				return false;

			var article = _articles.First(x => x.Name.Equals(articleName));

			AddPromotionArticle(article, discount, startDate, durationDays);

			return true;
		}

		public void SetChristmasPeriod(DateTime startDate, DateTime endDate)
		{
			AddSpecialPromotion(30, startDate, (endDate - startDate).Days);
		}

		public void SetClearancePeriod(DateTime startDate, int daysDuration)
		{
			AddSpecialPromotion(50, startDate, daysDuration);
		}

		private bool IsArticleNameInCollection(string name)
		{
			return _articles.FirstOrDefault(x => x.Name.Equals(name)) != null;
		}

		private IList<Promotion> GetActivePromotions(Article article, DateTime priceDate)
		{
			var special = _specialPromotions
				.Where(x => priceDate >= x.StartDate
							&& priceDate <= x.StartDate.AddDays(x.Duration));

			var general = _promotions
				.Where(x => x.ArticleId == article.Id
							&& priceDate >= x.StartDate
							&& priceDate <= x.StartDate.AddDays(x.Duration));

			return special.Concat(general).ToList();
		}

		private double ApplyPromotion(IList<Promotion> activePromotions, double originalPrice)
		{
			// https://stackoverflow.com/questions/1101841/linq-how-to-perform-max-on-a-property-of-all-objects-in-a-collection-and-ret/6330485#6330485
			var highestPromotionDiscount = activePromotions.Max(x => x.Discount);

			return originalPrice - (originalPrice * highestPromotionDiscount / 100);
		}

		private Article AddArticle(string name)
		{
			var article = new Article
			{
				Id = Guid.NewGuid(),
				Name = name
			};

			_articles.Add(article);

			return article;
		}

		private void AddPriceHistory(double price, DateTime insertionDateTime, Guid articleId)
		{
			_priceHistory.Add(new PriceHistory
			{
				ArticleId = articleId,
				Price = price,
				InsertionDateTime = insertionDateTime
			});
		}

		private void AddPromotionArticle(Article article, double discount, DateTime startDate, int durationDays)
		{
			_promotions.Add(CreatePromotionEntity(article, discount, startDate, durationDays));
		}

		private void AddSpecialPromotion(double discount, DateTime startDate, int durationDays)
		{
			_specialPromotions.Add(CreatePromotionEntity(null, discount, startDate, durationDays));
		}

		private Promotion CreatePromotionEntity(Article article, double discount, DateTime startDate, int durationDays)
		{
			return new Promotion
			{
				ArticleId = article == null ? Guid.Empty : article.Id,
				Discount = discount,
				Duration = durationDays,
				StartDate = startDate
			};
		}
	}
}
