using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    public abstract class InPersonCourse:Course
    {
        public int RoomNumber {  get; set; }
        public string Building {  get; set; }

        public InPersonCourse(int courseId, string title, string description, string instructorName, int maxStudents, int currentEnrollments, string category, int roomNumber, string building):base(courseId, title, description, instructorName, maxStudents, currentEnrollments, category)
        {
            RoomNumber = roomNumber;
            Building = building;
        }
        public override bool CanEnroll(Student student)
        {
            if (CurrentEnrollments<MaxStudents)
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
            return "In-Person";
        }
        public void DisplayCourseInfo()
        {
            Console.WriteLine($"IN-PERSON:{Title}");
            Console.WriteLine($"Course Id:{CourseId}");
            Console.WriteLine($"Instructor :{InstructorName}");
            Console.WriteLine($"Location:{Building},{RoomNumber}");
            Console.WriteLine($"Capacity:{CurrentStudents}/{MaxStudents}");
            Console.WriteLine($"Seats Remainig:{GetAvailableSeats}");
            Console.WriteLine($"Rating:{GetAverageRating():F1}");
            Console.WriteLine("Status:Open for Enrollment");
        }

    }
}
