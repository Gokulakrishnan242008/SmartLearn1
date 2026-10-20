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
        static User currentUser = null;
        
        public string Title { get; set; }
        public  Instructor instructor { get; set; }
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
        public int CurrentStudents { get; set; }
        public int ProgressPercentage{get; set; }
        public List<Course> standardcourses = new List<Course>();
        public Course(int courseId, string title, string description, string instructorName, int maxStudents, int currentEnrollments, string category,int currentStudents)
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
        public  void DisplayCourseInfo()
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
        public abstract bool CanEnroll();
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
            if (CanEnroll())
            {
                CurrentEnrollments++;
                student.EnrollInCourse(CourseId);
                if (student is INotifiable notifiable)
                {
                    notifiable.RecieveNotification($"Successfully enrolled in {Title}");
                }
            }
            if(instructor is INotifiable instructorNotifiable)
            {
                instructorNotifiable.SendNotification($"{student.Username}has enrolled in your course:{Title}");
            }
        }
        public void Drop(Student student)
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
            return ratings.Average();
        }
        public int GetTotalRatings()
        {
            return ratings.Count;
        }
        public abstract int GetAvailableSeats();
        public abstract string GetCourseType();
        static List<Course> courses = new List<Course>();

        static void BrowseCourses()
        {
            Console.Clear();

            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║                 AVAILABLE COURSES                ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");

            // Display every course using polymorphism
            
            foreach (Course course in courses)
            {
                Console.WriteLine();
                course.DisplayCourseInfo();


                Console.WriteLine($"Can Enroll: {(course.CanEnroll() ? "Yes" : "No")}");
                Console.WriteLine("──────────────────────────────────────────────────");
            }

            Console.Write("\nEnter Course ID to enroll: ");
             if(!int.TryParse(Console.ReadLine(),out int courseId))
            {
                Console.WriteLine("invalid CourseId.");
                return;
            }

            // Find selected course
            Course selectedCourse = courses.FirstOrDefault(c =>c.CourseId == courseId);

            if (selectedCourse == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }
            // Polymorphic Enroll()
            if (currentUser is not Student student)
            {
                Console.WriteLine("Only students can enroll in courses");
                return;
            }
            // Polymorphic CanEnroll()
            if (!selectedCourse.CanEnroll())
            {
                Console.WriteLine("❌ You cannot enroll in this course.");
                return;
            }
           selectedCourse.Enroll(student);
           Console.WriteLine("✅ Enrollment completed successfully!");
        }
        public List<Course> GetPopularCourses(int count)
        {
            return standardcourses.OrderByDescending(c => c.CurrentEnrollments).Take(count).ToList();
        }
        public List<Course>GetCoursesNeedingstudents()
        {
            return standardcourses.Where(c=>c.CurrentEnrollments<5).ToList();
        }
        public List<Course>GetHighestRatedCourses(int count)
        {
            return standardcourses.OrderByDescending(s=>s.GetAverageRating()).Take(count).ToList();
        }
        public List<Course>GetCoursesByInstructor(string instructorName)
        {
            return standardcourses.Where(c=>c.InstructorName.Equals(instructorName,StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Course> GetCoursesByCategory(string category)
        { 
         return standardcourses.Where(c=>c.Category.Equals(category,StringComparison.OrdinalIgnoreCase)).OrderByDescending(c=>c.AddRating()).ToList();
        }
        public List<Course>GetMostEnrolledCategory()
        {
            return standardcourses.GroupBy(c => c.Category).OrderByDescending(g=>g.Sum(c=>c.CurrentEnrollments).Select(g.Key).FirstOrDefault());
        }
        public List<Course> AreAllCoursesFilled()
        {
            return ;
        }
        public void DisplaySearchResults(List<Course> results)
        {
            if (results == null || results.Count == 0)
            {
                Console.WriteLine("No courses found .");
                return;
            }
            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine("                  Search Results");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");
            Console.WriteLine($"{"ID",-6}{"Title",-25}{"Category",-15}{"Instructor",-20}{"Enrolled",-10}");
            foreach (Course course in results)
            {
                Console.WriteLine($"{course.CourseId,-6}" + $"{course.Title,-25}" + $"{course.Category,-15}" + $"{course.InstructorName,-20}" + $"{course.CurrentEnrollments,-10}");
            }
        }
        public void GetCourseStatistics()
        {
            Console.WriteLine($"Number of Courses:StandardCourses.Count");
            double average = Student.Average(s => s.ProgressPercentage);
            Console.WriteLine($"Average Progress:{average:F2}%");
            Course highestCourse = StandardCourse.OrderByDescending(c => c.CurrentEnrollments).FirstOrDefault();
            if (highestCourse != null) 
            {
                Console.WriteLine($"Highest Enrollment Course:{highestCourse.Title}");
                Console.WriteLine($"Total Enrollment:{highestCourse.CurrentEnrollments}");
            }
            else
            {
                Console.WriteLine("No courses available");
            }
            Course lowestCourse=StandardCourse.OrderBy(c=>c.CurrentEnrollments).FirstOrDefault();
            if (lowestCourse != null)
            {
                Console.WriteLine($"Lowest Enrollment Course:{lowestCourse.Title}");
                Console.WriteLine($"Total Enrollment:{lowestCourse.CurrentEnrollments}");
            }
            else
                Console.WriteLine("No courses available");
            var categorystats = StandardCourse.GroupBy(c => c.Category);
            foreach (var group in categorystats) 
            {
                int totalEnrollments = group.Sum(c => c.CurrentEnrollments);
                Console.WriteLine($"Category:{group.Key}");
                Console.WriteLine($"Total Enrollments:{totalEnrollments}");
                Console.WriteLine("------------");
            }

        }


    }
}
