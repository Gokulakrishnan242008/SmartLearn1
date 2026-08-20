using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SmartLearn
{
    public class SearchEngine
    {
        
        
           
            public static List<ISearchable> Search(List<ISearchable> items, string keyword)
            {
                List<ISearchable> results = new List<ISearchable>();

                foreach (ISearchable item in items)
                {
                    if (item.MatchesSearch(keyword))
                    {
                        results.Add(item);
                    }
                }
                return results;
            }
            public List<string> GetSearchSummary()
            {
                List <string> summary=new List<string> ();
                return summary;
            }
            
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
                    Console.WriteLine($"{result.GetSearchSummary()}");
                 }
                    
            }
            
        }
    }

