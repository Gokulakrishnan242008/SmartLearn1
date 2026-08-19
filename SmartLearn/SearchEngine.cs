using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SmartLearn
{
    class SearchEngine
    {
        public class Search()
        {
           
            public static List<ISearchable> Searchs(List<ISearchable> items, string keyword)
            {
                List<ISearchable> results = new List<ISearchable>();

                foreach (ISearchable item in items)
                {
                    if (items.MatchesSearch(keyword))
                    {
                        results.Add(item);
                    }
                }
                return results;
            }
             List<string> GetSearchSummary();
            public static void DisplayResults(List<ISearchable> results)
            { 
                if(results.Count==0)
                {
                    Console.WriteLine("No results found");
                    return;
                }
                Console.WriteLine($"\n===Search Results===({results.Count})");
                
                foreach (ISearchable result in results)
                {
                    Console.WriteLine($"{results.GetSearchSummary()}");
                 }
                    
            }
            
        }
    }
}
