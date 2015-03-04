namespace TKTManager.Test
{
	using System;
	using NUnit.Framework;
	using Contracts;

    public class PriceManager
    {
		private TKTManager.PriceManager _priceManager;

		[SetUp]
		public void SetUp()
		{
			ICatalogManager catalogManager = new CatalogManager();

			_priceManager = new TKTManager.PriceManager(catalogManager);
		}

		[Test]
		public void If_article_exists_throw_ArgumentException()
		{
			_priceManager.AddArticle("Article A", 30, DateTime.UtcNow);

			Assert.Throws<ArgumentException>(() => _priceManager.AddArticle("Article A", 30, DateTime.UtcNow));
		}

		[Test]
		public void Show_all_articles_name()
		{
			var articleNames = new[] { "Article A", "Article B" };

			_priceManager.AddArticle("Article A", 30, DateTime.UtcNow);
			_priceManager.AddArticle("Article B", 50, DateTime.UtcNow);

			CollectionAssert.AreEquivalent(_priceManager.GetArticleNames(), articleNames);
		}

		[Test]
		public void Return_article_price_for_specific_date()
		{
			var datetime = new DateTime(2015, 02, 26);

			_priceManager.AddArticle("Article A", 30, datetime);
			var price = _priceManager.GetPrice("Article A", datetime);

			Assert.AreEqual(price, 30);
		}

		[Test]
		public void If_article_does_not_exists_in_specific_date_throw_an_Exception()
		{
			var dateTime = new DateTime(2014, 10, 20);

			_priceManager.AddArticle("Article A", 30, DateTime.UtcNow);

			Assert.Throws<Exception>(() => _priceManager.GetPrice("Article A", dateTime));
		}

		[Test]
		public void If_promotion_can_be_added_return_true()
		{
			_priceManager.AddArticle("Article A", 30, DateTime.UtcNow);

			var IsAdded = _priceManager.AddPromotion("Article A", 5, DateTime.UtcNow, 10);

			Assert.IsTrue(IsAdded);
		}

		[Test]
		public void If_promotion_cannot_be_added_return_false()
		{
			var IsAdded = _priceManager.AddPromotion("Article A", 5, DateTime.UtcNow, 10);

			Assert.IsFalse(IsAdded);
		}

		[Test]
		public void If_one_promotion_is_active_for_a_product_return_price_reduced()
		{
			var articleDate = new DateTime(2015, 02, 20);
			var promotionDate = new DateTime(2015, 02, 16);

			_priceManager.AddArticle("Article A", 100, articleDate);

			var IsAdded = _priceManager.AddPromotion("Article A", 5, promotionDate, 10);

			var price = _priceManager.GetPrice("Article A", articleDate);

			Assert.IsTrue(IsAdded);
			Assert.AreEqual(price, 95);
		}

		[Test]
		public void If_two_promotions_are_active_for_a_product_return_price_with_highest_discount()
		{
			var articleDate = new DateTime(2015, 02, 20);
			var promotionDateA = new DateTime(2015, 02, 16);
			var promotionDateB = new DateTime(2015, 02, 19);

			_priceManager.AddArticle("Article A", 100, articleDate);

			var IsAddedA = _priceManager.AddPromotion("Article A", 5, promotionDateA, 10);
			var IsAddedB = _priceManager.AddPromotion("Article A", 10, promotionDateB, 10);

			var price = _priceManager.GetPrice("Article A", articleDate);

			Assert.IsTrue(IsAddedA);
			Assert.IsTrue(IsAddedB);
			Assert.AreEqual(price, 90);
		}

		[Test]
		public void If_Christmas_period_is_active_a_30_percent_off_is_applied()
		{
			var articleDate = new DateTime(2015, 12, 25);
			var campaignStart = new DateTime(2015, 12, 15);
			var campaignEnd = new DateTime(2015, 12, 31);

			_priceManager.AddArticle("Article A", 100, articleDate);

			_priceManager.SetChristmasPeriod(campaignStart, campaignEnd);

			var price = _priceManager.GetPrice("Article A", articleDate);

			Assert.AreEqual(price, 70);
		}

		[Test]
		public void If_Clearance_period_is_active_a_50_percent_off_is_applied()
		{
			var articleDate = new DateTime(2015, 10, 15);
			var campaignStart = new DateTime(2015, 10, 12);

			_priceManager.AddArticle("Article A", 100, articleDate);

			_priceManager.SetClearancePeriod(campaignStart, 4);

			var price = _priceManager.GetPrice("Article A", articleDate);

			Assert.AreEqual(price, 50);
		}
    }
}
