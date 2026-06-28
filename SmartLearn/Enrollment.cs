using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string StudentUserName { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int ProgressPercentage { get; set; }
        public bool IsCompleted {  get; set; }
        public Enrollment (int enrollmentId,string studentUserName,int courseId,DateTime enrollment,int progressPercentage,bool isCompleted )
        { 
            EnrollmentId = enrollmentId;
            StudentUserName = studentUserName;
            CourseId = courseId;
            EnrollmentDate = enrollment;
            ProgressPercentage = progressPercentage;
            IsCompleted = isCompleted;
           
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"EnrollmentId:{EnrollmentId}");
            Console.WriteLine($"StudentUserName:{StudentUserName}");
            Console.WriteLine($"CourseId:{CourseId}");
            Console.WriteLine($"EnrollmentDate:{EnrollmentDate}");
            Console.WriteLine($"ProgressPercentage:{ProgressPercentage}");
            Console.WriteLine($"IsCompleted:{IsCompleted}");
        }
     
    }


}
