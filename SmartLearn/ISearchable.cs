using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    public interface ISearchable
    {
       public  bool MatchesSearch(string keyword);
        string GetSearchSummary();
    }
}
