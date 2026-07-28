using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SmartLearn
{
    
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstructorName { get; set; }
        public int MaxStudents { get; set; }
        public int CurrentEnrollments {  get; set; }
        public string Category { get; set; }

        public Course(int courseId,string title, string description, string instructorName, int maxStudents,int currentEnrollments,string category)
        {
            CourseId = courseId;
            Title = title;
            Description = description;
            InstructorName = instructorName;
            MaxStudents = maxStudents ;
            CurrentEnrollments = currentEnrollments;
            Category = category; 
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"CourseId:{CourseId}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"InstructorName: {InstructorName}");
            Console.WriteLine($"MaxStudents:{MaxStudents}");
            Console.WriteLine($"CurrentEnrollments:{CurrentEnrollments}");
            Console.WriteLine($"Category:{Category}");
        }
        public bool CanEnroll()
        {
            return CurrentEnrollments < MaxStudents;

         }
        public void IncrementEnrollment()
        {
            if (CurrentEnrollments < MaxStudents)
            {
                CurrentEnrollments++;
                
            }
        }
        public void DecrementEnrollment()
        {
            if (CurrentEnrollments > 0)
            {
                CurrentEnrollments--;
            }
        }
      

    }
}
