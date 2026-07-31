using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    interface ISearchable
    {
        bool MatchesSearch(string keyword);
        string GetSearchSummary();
    }
}
