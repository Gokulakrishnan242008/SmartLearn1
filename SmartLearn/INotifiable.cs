using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    interface INotifiable
    {
        void SendNotification(string message);
        List<string> GetNotificationHistory();
    }
}
