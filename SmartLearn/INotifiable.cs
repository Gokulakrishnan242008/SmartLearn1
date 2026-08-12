using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    public interface INotifiable
    {
     public   abstract void SendNotification(string message);
        public List<string> GetNotificationHistory();
    }
}
