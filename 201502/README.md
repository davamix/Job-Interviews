### Prices manager

Implement this interface with the requirements:

```
interface IPriceManager
{
    void AddArticle(string name, double price, DateTime insertionDateTime);
    bool AddPromotion (string articleName, double discount, DateTime startDate, int durationDays);
    double GetPrice(string name, DateTime date);
    IEnumerable<string> GetArticleNames();
    void SetChristmasPeriod(DateTime startDate, DateTime endDate);
    void SetClearancePeriod(DateTime startDate, int DaysDuration);
}

```

* An user adds articles in the catalog using the method AddArticle.

* When AddArticle method is called and the article exists in the catalog, an ArgumentException will be thrown.

* GetArticleNames method returns article's names of all articles in catalog.

* GetPrice method returns the price of an article in a specific date. If the article doesn't exist, an exception with the text "Article [name] doesn't exist", will be thrown.

* An user set a promotion with the AddPromotion method. The promotions have a start date and days during which apply the discount.

* SetChristmasPeriod method sets the Christmas' discount period, in which 30% off is applied to all articles.

* SetClearancePeriod method sets a period during which 50% off is applied to all articles.

* If you have several promotions for the same product at the same time, apply the highest.
