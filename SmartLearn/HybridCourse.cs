using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    public  class HybridCourse:Course
    {
        public int MaxStudents { get; set; }
        private int maxStudents 
        {
            get {  return MaxStudents; }
            set
            {
                if(value > 0)
                {
                    Console.WriteLine("Error:Max students must be greater than 0");
                    return;
                }
                value = MaxStudents;
            }
        }
        public int RoomNumber { get; set; }
        public string Building { get; set; }
        public int OnlineVideoDuration { get; set; }
        public List<DateTime> InPersonSessions { get; set; }=new List<DateTime>();
        

        public HybridCourse(int courseId, string title, string description, string instructorName, int maxStudents, int currentEnrollments, string category, int currentStudents, int onlineVideoDuration, int roomNumber, string building, List<DateTime> inPersonSessions) : base(courseId, title, description, instructorName, maxStudents, currentEnrollments, category, currentStudents)
        {
            MaxStudents = maxStudents;
            RoomNumber = roomNumber;
            Building = building;
            OnlineVideoDuration = onlineVideoDuration;
            InPersonSessions = inPersonSessions;
        }
        static List<Course> course = new List<Course>();
        static void InitializeCourses()
        {
            course.Add(new HybridCourse(301, "Full-Stack Development", "Learn data science concepts and techniques", "Prof. Smith", 30, 0, "Data Science", 0, 720, 101, "Building A", new List<DateTime> { new DateTime(2024, 6, 1, 9, 0, 0), new DateTime(2024, 6, 8, 9, 0, 0) }));
            course.Add(new HybridCourse(302, "Web Development Bootcamp", "Learn web development concepts and techniques", "Prof. Johnson", 25, 0, "Web Development", 0, 600, 205, "Building B", new List<DateTime> { new DateTime(2024, 6, 2, 10, 0, 0), new DateTime(2024, 6, 9, 10, 0, 0) }));
        }
        public  bool CanEnroll(Student student)
        {
            if (CurrentEnrollments < MaxStudents)
            {
                return true;
            }
            return false;
        }
        public override int GetAvailableSeats()
        {
            return MaxStudents - CurrentEnrollments;
        }
        public override string GetCourseType()
        {
            return "Hybrid";
        }
        public void DisplayCourseInfo()
        {
            Console.WriteLine($"HYBRID:{Title}");
            Console.WriteLine($"Course Id:{CourseId}");
            Console.WriteLine($"Instructor:{InstructorName}");
            Console.WriteLine($"Category:{Category}");
            Console.WriteLine($"Online Component:{OnlineVideoDuration} minutes");
            Console.WriteLine($"In-Person Location:{Building},{RoomNumber}");
            Console.WriteLine($"Capacity:{CurrentStudents}/{MaxStudents}");
            Console.WriteLine($"Seats Remaining:{GetAvailableSeats()}");
            Console.WriteLine($"Rating:{GetAverageRating():F1}");
            Console.WriteLine("Status:Open for Enrollment");
        }

    }
}
