using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    interface ISearchable
    {
       public abstract bool MatchesSearch(string keyword);
        string GetSearchSummary();
    }
}
