using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.WebRequestMethods;

namespace SmartLearn
 {
   public class OnlineCourse: Course
    {
        public int VideoDurationMinutes{get;set;}

        public string StreamUrl { get; private set;  }
        public string Capacity {  get; private set; }
        public int CurrentStudents { get; set; }

            public OnlineCourse(int courseId,string title,string description,string instructorName,int maxStudents,int currentEnrollments,string category,int videoDurationMinutes,int streamUrl,string capacity,int currentStudents):base(courseId,title,description,instructorName,maxStudents,currentEnrollments,category,currentStudents)
        {
            VideoDurationMinutes = videoDurationMinutes;
            StreamUrl = "https.//smartLearn.com/stream"+CourseId;
            Capacity = "Unlimited";
            CurrentStudents = currentStudents;
        }
        public bool CanEnroll(Student student) 
        { 
            return true;
        }
        public override int GetAvailableSeats()
        {
            return int.MaxValue;
        }
        public override string GetCourseType() 
        {
         return "Online";
        }
        public void DisplayCourseInfo()
        {
            Console.WriteLine($"Online:{Title}");
            Console.WriteLine($"Course Id:{CourseId}");
            Console.WriteLine($"Instructor:{InstructorName}");
            Console.WriteLine($"Category:{Category}");
            Console.WriteLine($"Duration:{VideoDurationMinutes}Minutes");
            Console.WriteLine("Capacity:Unlimited");
            Console.WriteLine($"Current Students:{CurrentStudents}");
            Console.WriteLine($"Rating:{GetAverageRating():F1}");
            Console.WriteLine("Status:Open For Enrollment");

        }
        static List<Course>Courses = new List<Course>();
        
    }
}
