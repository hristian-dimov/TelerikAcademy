using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Feedzilla
{
    class ArticlesConsumer
    {
        private readonly HttpClient client;

        public ArticlesConsumer(string url)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ArticlesCollection GetArticles(string queryString)
        {
            var response = client.GetAsync(string.Format("v1/articles/search.json?q={0}", queryString)).Result;

            if (response.IsSuccessStatusCode)
            {
                var articles = response.Content.ReadAsAsync<ArticlesCollection>().Result;

                return articles;
            }
            else
            {
                throw new HttpRequestException(string.Format("Get faild! Statuse code: {0}. Reason: {1}",
                    (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public ArticlesCollection GetArticles(string queryString, int count)
        {
            var response = client.GetAsync(string.Format("v1/articles/search.json?q={0}&count={1}", queryString, count)).Result;

            if (response.IsSuccessStatusCode)
            {
                ArticlesCollection articles = response.Content.ReadAsAsync<ArticlesCollection>().Result;

                return articles;
            }
            else
            {
                throw new HttpRequestException(string.Format("Get faild! Statuse code: {0}. Reason: {1}",
                    (int)response.StatusCode, response.ReasonPhrase));
            }
        }
    }
}