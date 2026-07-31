using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{

    public interface IRatable
    {
        void AddRating(int stars, string review);
        double GetAverageRating();
        int GetTotalRatings();
    }



        
     
}
