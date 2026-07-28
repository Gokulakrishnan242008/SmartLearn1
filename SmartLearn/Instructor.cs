using SmartLearn;
using System;
using System.Collections.Generic;
using System.Text;

public abstract class Instructor : User
{
    public string Department {  get; set; }
    public List<Course> CoursesTeaching { get; set; }= new List<Course>();
    public List<int> CreatedCourseIds { get; set; }
    public Instructor(string username, string password, string email) : base(username, password, email)
    {
        CreatedCourseIds = new List<int>();
    }
    public override string GetUserType()
    {
        return "Instructor";
    }
    public override void DisplayInfo()
    {
             base.DisplayInfo();
        Console.WriteLine($"Department;{Department}");
        Console.WriteLine($"CoursesTeaching;{CoursesTeaching.Count}");
    }
    public int GetStudentCount(List<Enrollment> enrollments)
    { 
     int studentCount = 0;
        foreach (var courseId in CreatedCourseIds)
        {
            foreach (var enrollment in enrollments)
            {
                if (enrollment.CourseId == courseId)
                {
                    studentCount++;
                }
            }
        }
        return studentCount;
    }
    public void GetCourseById(int courseId, List<Course> courses)
    {
        foreach (var course in courses)
        {
            if (course.CourseId == courseId)
            {
                course.DisplayInfo();
                return;
            }
        }
        Console.WriteLine("❌ Course not found!");
    }
    public void AddCourse(int courseId)
    {
        if (!CreatedCourseIds.Contains(courseId))
        {
            CreatedCourseIds.Add(courseId);
            Console.WriteLine("✓ Course created successfully!");
        }
        else
        {
            Console.WriteLine("❌ Course already exists!");
        }
    }
    public void RemoveCourse(int courseId)
    {
        if (CreatedCourseIds.Contains(courseId))
        {
            CreatedCourseIds.Remove(courseId);
            Console.WriteLine("✓ Course removed successfully!");
        }
        else
        {
            Console.WriteLine("❌ Course not found!");
        }
    }
    public void ShowMyCourses()
    {
        if (CreatedCourseIds.Count == 0)
        {
            Console.WriteLine("No courses created.");
            return;
        }
        Console.WriteLine("Created Courses:");
        foreach (var courseId in CreatedCourseIds)
        {
            Console.WriteLine($"Course ID: {courseId}");
        }
    }
    public override void DisplayDashboard()
    {
      
        Console.WriteLine("");
        Console.WriteLine("          INSTRUCTOR DASHBOARD          ");
        Console.WriteLine("");
        Console.WriteLine($"Welcome,Professor: {Username}!");
        Console.WriteLine("Department name: Computer Science");
        Console.WriteLine($"Teaching:{CoursesTeaching.Count}courses");
        Console.WriteLine("My Courses");
        Console.WriteLine("Create New Course");
        Console.WriteLine("View Student Roster");
        Console.WriteLine("Grade Assignments");
        Console.WriteLine("Logout");
    }
}
