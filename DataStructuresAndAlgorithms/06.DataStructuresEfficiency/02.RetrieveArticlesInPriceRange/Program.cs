using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.RetrieveArticlesInPriceRange
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedMultiDictionary<int, Article> articles = new OrderedMultiDictionary<int, Article>(true);
            int articlesToAddCount = 1000000;
            AddManyArticles(articles, articlesToAddCount);
            var articlesInPriceRange = articles.Range(200, true, 500, true);
            foreach (var keyValuePair in articlesInPriceRange)
            {
                Console.WriteLine(keyValuePair.Value);
            }
        }

        private static void AddManyArticles(OrderedMultiDictionary<int, Article> articles, int count)
        {
            var articlePrice = 100;
            for (int i = 0; i < count; i++)
            {
                if (i % 10 == 0)
                {
                    articlePrice += i;
                }
                Article newArticle = new Article("Barcode" + i, "Vendor" + i, "Title" + i, articlePrice);
                articles.Add(newArticle.Price, newArticle);
            }
        }
    }
}
