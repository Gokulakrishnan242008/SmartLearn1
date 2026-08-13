using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    class SearchEngine
    {
        public static class Search()
        {
            public static List<ISearchable> Search(List<ISearchable> items, string keyword)
            {
                List<ISearchable> results = new List<ISearchable>();
                foreach (ISearchable searchable in items)
                {
                    if (items.MatchesSearch(keyword))
                    {
                        results.Add(searchable);
                    }
                }
                return results;
            }
            public static void DisplayResults(List<ISearchable> results)
            { 
                if(results.Count==0)
                {
                    Console.WriteLine("No results found");
                    return;
                }
                Console.WriteLine("\n===Search Results===");
                foreach (ISearchable searchable in results)
                {
                    Console.WriteLine($"{results.GetSearchSummary()}");
                 }
                    )
            }
            
        }
    }
}
