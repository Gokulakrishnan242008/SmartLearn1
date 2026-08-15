using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;

namespace SmartLearn
{

    public abstract class Course : IEnrollable, ISearchable, IRatable
    {
        private List<int> ratings = new List<int>();
        private List<string> reviews = new List<string>();
        public int CourseId { get; set; }
        public string Title { get; set; }
        private string title 
        { get { return Title; }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Title Cannot be null,empty or WhiteSpace");
                    return;
                }
                if(value.Length>100)
                {
                    Console.WriteLine("Error:Title must be 1-100");
                    return;
                }
            }
        }
        public string Description { get; set; }
        public string InstructorName { get; set; }
        public int MaxStudents { get; set; }
        public int CurrentEnrollments { get; set; }
        public string Category { get; set; }
        public string CurrentStudents { get; set; }

        public Course(int courseId, string title, string description, string instructorName, int maxStudents, int currentEnrollments, string category,string currentStudents)
        {
            CourseId = courseId;
            Title = title;
            Description = description;
            InstructorName = instructorName;
            MaxStudents = maxStudents;
            CurrentEnrollments = currentEnrollments;
            Category = category;
            CurrentStudents = currentStudents;
        }
        public  void DisplayInfo()
        {
            Console.WriteLine($"CourseId:{CourseId}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"InstructorName: {InstructorName}");
            Console.WriteLine($"MaxStudents:{MaxStudents}");
            Console.WriteLine($"CurrentEnrollments:{CurrentEnrollments}");
            Console.WriteLine($"Category:{Category}");
            Console.WriteLine($"CurrentStudents:{CurrentStudents}");
        }
        public override bool CanEnroll(Student student)
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
        public void Enroll(Student student)
        {
            if (CanEnroll(student))
            {
                CurrentEnrollments++;
                student.EnrollInCourse();
                if (student is INotifiable notifiable)
                {
                    notifiable.RecieveNotification($"Successfully enrolled in {Title}");
                }
            }
            if(Instructor is INotifiable instructorNotifiable)
            {
                instructorNotifiable.SendNotification($"{student.Username}has enrolled in your course:{Title}");
            }
        }
        public void Drop()
        {
            if (CurrentEnrollments > 0)
            {
                CurrentEnrollments--;
            }
        }
        public bool MatchesSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return false;
            keyword = keyword.ToLower();
            return Title.ToLower().Contains(keyword) || Description.ToLower().Contains(keyword) || Category.ToLower().Contains(keyword) || InstructorName.ToLower().Contains(keyword);
        }
        public string GetSearchSummary()
        {
            return $"Course.:{Title}|Category:{Category}|Instructor:{InstructorName}";
        }

        public void AddRating(int stars, string review)
        {
            if (stars < 1 || stars > 5)
            {
                Console.WriteLine("stars must be 1-5");
            }
            ratings.Add(stars);
            reviews.Add(review);
            Console.WriteLine("Ratings added Successfully!");
        }
        public double GetAverageRating()
        {
            if (ratings.Count == 0)
            {
                return 0;
            }
        }
        public int GetTotalRating()
        {
            return ratings().Count;
        }
        public abstract int GetAvailableSeats();
        public abstract string GetCourseType();
        
    }
}
