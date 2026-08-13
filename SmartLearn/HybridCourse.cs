using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    public abstract class HybridCourse:Course
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
        public string RoomNumber { get; set; }
        public string Building { get; set; }
        public int OnlineVideoDuration { get; set; }
        public List<DateTime> InPersonSessions { get; set; }=new List<DateTime>();

        public HybridCourse(int courseId, string title, string description, string instructorName, int maxStudents, int currentEnrollments, string category, string currentStudents, int onlineVideoDuration, string roomNumber, string building, List<DateTime> inPersonSessions) : base(courseId, title, description, instructorName, maxStudents, currentEnrollments, category, currentStudents)
        {
            MaxStudents = maxStudents;
            RoomNumber = roomNumber;
            Building = building;
            OnlineVideoDuration = onlineVideoDuration;
            InPersonSessions = inPersonSessions;
        }
        public override bool CanEnroll(Student student)
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
