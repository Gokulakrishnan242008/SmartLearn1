using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    public class InPersonCourse:Course
    {
        public int RoomNumber {  get; set; }
        public string Building {  get; set; }
        public int MaxStudents {  get; set; }
        private int maxStudents
        {
            get { return MaxStudents; }
            set
            {
                if (value > 0)
                {
                    Console.WriteLine("Error:Max students must be greater than 0");
                    return;
                }
                value = MaxStudents;
            }
        }

        public InPersonCourse(int courseId, string title, string description, string instructorName, int maxStudents, int currentEnrollments, string category, int currentStudents,int roomNumber, string building):base(courseId, title, description, instructorName, maxStudents, currentEnrollments, category,currentStudents )
        {
            RoomNumber = roomNumber;
            Building = building;
        }
        static List<Course> course = new List<Course>();
        static void InitializeCourses()
        {
            course.Add(new InPersonCourse (201, "Database Design Workshop", "Learn the basics of programming using C#", "John Smith", 25, 0, "Computer Science",0,  101, "Room A"));
            course.Add(new InPersonCourse(202, "Network Security Lab", "Practical Laboratory sessions covering network security", "John steve", 20, 0, "Web Development",0, 205, "Room C"));
            course.Add(new InPersonCourse(203,"Mobile App Development","Learn the fundamentals of mobile application development ","John keyn",30,0,"Web Development",0,301,"Room A"));
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
