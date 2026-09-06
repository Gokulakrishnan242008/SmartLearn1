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
       public bool CanEnroll(Student student)
        {
            return true;
        }
         public abstract int GetAvailableSeats();

        
        
    }
}
