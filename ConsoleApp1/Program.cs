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
            if (args.Length < 1) throw new ArgumentException();
            var websiteUrl = args[0];
            var httpClient = new HttpClient();
            var response = await HttpClient.GetAsync(websiteUrl);

            Console.WriteLine(response);

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);

            var regex = new Regex(@""); //do uzupelnienia

            var a = $"Content: {content}";
            var b = @"\a";

            var matchCollection = regex.Matches(content);

            var set = new HashSet<string>();

            foreach(var item in matchCollection)
            {
                set.add(item.ToString());
            }

            foreach(var item in set) 
            {
                Console.WriteLine(item);
            }



        }
    }
}
