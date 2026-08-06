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
       public abstract bool CanEnroll(Student student);
         public abstract int GetAvailableSeats();

        
        
    }
}
