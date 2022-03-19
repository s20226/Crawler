using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        public async static Task Main(string[] args)
        {

            if (args.Length < 1) throw new ArgumentNullException("Program execute without args");


            var websiteUrl = args[0];
            if (!CheckURLValid(websiteUrl)) throw new ArgumentException("Not Valid URL");

            var httpClient = new HttpClient();
            String content;
            try
            {
                var response = await httpClient.GetAsync(websiteUrl);
                content = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException)
            {
                throw new HttpRequestException("Blad podczas pobierania strony");
            }

            httpClient.Dispose();
            var regex = new Regex(@"(?:([a-zA-Z0-9+._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+))");
            //  var regex = new Regex(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])");


            var matchCollection = regex.Matches(content);

            var set = new HashSet<string>();

            foreach (var item in matchCollection)
            {
                set.Add(item.ToString());
            }
            if (set.Count == 0) Console.WriteLine("Nie znaleziono adresow email");

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }


        }

        private static bool CheckURLValid(string websiteUrl)
        {
            Uri uriResult;
            return Uri.TryCreate(websiteUrl, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        }
    }

}


