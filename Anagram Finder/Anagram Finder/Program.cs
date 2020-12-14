using System;
using Microsoft.Extensions.DependencyInjection;
namespace Anagram_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Register services using IoC containers
            ServiceProvider serviceProvider = RegisterServices();

            var listOfWorkds = GetWordList(serviceProvider);

            FindAnagrams(listOfWorkds);

            Console.ReadLine();
        }

        private static void FindAnagrams(System.Threading.Tasks.Task<System.Collections.Generic.List<string>> listOfWorkds)
        {
            Console.WriteLine("Please enter input string");
            string input = Console.ReadLine();
            Console.WriteLine("************Anagrams**************");

            //Register anagram logic as a filter in pipeline and process
            var filterResults = PipelineFactory.Instance().Process(listOfWorkds.Result, new UserFilters() { InputAnagram = input });

            foreach (var result in filterResults)
                Console.WriteLine(result);
        }

        private static System.Threading.Tasks.Task<System.Collections.Generic.List<string>> GetWordList(ServiceProvider serviceProvider)
        {
            //Read wordlist file
            var dataAdapter = serviceProvider.GetService<IDataAdapter>();            
            var listOfWorkds = dataAdapter.ReadFile("Anagram_Finder.Data.Wordlist.txt");
            return listOfWorkds;
        }

        private static ServiceProvider RegisterServices()
        {
            return new ServiceCollection()
                        .AddSingleton<IDataStore, DataStore>()
                        .AddScoped<IDataAdapter, DataAdapter>()
                        .AddScoped<IPipeLine, PipeLine>()
                        .AddScoped<Base.IFilters, Base.Anagram>()
                        .BuildServiceProvider();
        }
    }
}
