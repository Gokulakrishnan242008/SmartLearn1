using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLearn
{
    public class InPersonCourse:Course
    {
        public string RoomNumber {  get; set; }
        public string Building {  get; set; }

        public InPersonCourse(int courseId, string title, string description, string instructorName, int maxStudents, int currentEnrollments, string category, string roomNumber, string building):base(courseId, title, description, instructorName, maxStudents, currentEnrollments, category)
        {
            RoomNumber = roomNumber;
            Building = building;
        }
    }
}
