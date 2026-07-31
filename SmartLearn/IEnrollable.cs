using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SmartLearn
{
    public interface IEnrollable
    {
        void Enroll(Student student);
        void Drop(Student student);
        bool CanEnroll(Student student);
         int GetAvailableSeats();

        
        
    }
}
