using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        public async static Task Main(string[] args)
        {
            var websiteUrl = args[0];
            var httpClient = new HttpClient();
            var response = await HttpClient.GetAsync(websiteUrl);

            Console.WriteLine(response);

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);

            var regex = new Regex(@"");

            var a = $"Content: {content}";
            var b = @"\a";

            var matchCollection = regex.Matches(content);


        }
    }
}
