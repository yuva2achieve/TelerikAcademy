using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace Feedzilla.Client
{
    class MainClass
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.feedzilla.com/");
            Console.WriteLine("Enter search text:");
            string searchString = Console.ReadLine();
            string url = "v1/articles/search.json?q=" + searchString;
            PrintArticles(client, url);
            Console.ReadLine();
        }

        private static async void PrintArticles(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var articles = await response.Content.ReadAsStringAsync();
            var articlesCollection = JsonConvert.DeserializeObject<ArticlesCollection>(articles);

            foreach (var article in articlesCollection.Articles)
            {
                var currentArticle = JsonConvert.DeserializeObject<Article>(article.ToString());
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Title: " + currentArticle.Title);
                Console.WriteLine("Url: " + currentArticle.Url);
            }
        }
    }
}
