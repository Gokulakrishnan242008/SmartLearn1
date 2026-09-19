using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    public class StandardCourse : Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstructorName { get; set; }
        public int MaxStudents { get; set; }
        public int CurrentEnrollments { get; set; }
        public string Category { get; set; }
        public int CurrentStudents {  get; set; }
        public StandardCourse(int courseId, string title, string description, string instructorName, int maxStudents, int currentEnrollments, string category,int currentStudents) : base(courseId, title, description, instructorName, maxStudents, currentEnrollments,category,currentStudents) { }

        public  void DisplayCourseInfo()
        {
            Console.WriteLine($"CourseId:{ CourseId}");
            Console.WriteLine($"Title:{Title}");
            Console.WriteLine($"Description:{Description}");
            Console.WriteLine($"InstructorName:{InstructorName}");
            Console.WriteLine($"MaxStudents:{MaxStudents}");
            Console.WriteLine($"CurrentEnrollments:{CurrentEnrollments}");
            Console.WriteLine($"Category:{Category}");  
            Console.WriteLine($"CurrentStudents:{CurrentStudents}");
        }
        public override int GetAvailableSeats()
        {
            return MaxStudents-CurrentEnrollments;
        }
        public override string GetCourseType()
        {
            return "Standard";
        }
        public override bool CanEnroll()
        {
            if (CurrentEnrollments < MaxStudents)
            {
                return true;
            }
            return false;
        }
    }

}
