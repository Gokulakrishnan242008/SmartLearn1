using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string StudentUsername { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int ProgressPercentage { get; set; }
        public bool IsCompleted { get; set; }
        public Enrollment(int enrollmentId, string studentUsername, string courseTitle, int courseId, bool isCompleted)
        {
            EnrollmentId = enrollmentId;
            StudentUsername = studentUsername;
            CourseId = courseId;
            CourseTitle = courseTitle;
            EnrollmentDate = DateTime.Now;
            ProgressPercentage = 0;
            IsCompleted = isCompleted;

        }
        public void DisplayInfo()
        {
            Console.WriteLine($"EnrollmentId:{EnrollmentId}");
            Console.WriteLine($"StudentUserName:{StudentUsername}");
            Console.WriteLine($"CourseId:{CourseId}");
            Console.WriteLine($"CourseTitle:{CourseTitle}");
            Console.WriteLine($"EnrollmentDate:{EnrollmentDate}");
            Console.WriteLine($"ProgressPercentage:{ProgressPercentage}");
            Console.WriteLine($"IsCompleted:{IsCompleted}");
        }

        public void UpdateProgress(int ProgressPercentage)
        { }


    }
}
