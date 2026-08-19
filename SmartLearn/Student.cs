using SmartLearn;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
public abstract class  Student : User,ISearchable,INotifiable
{
    public List<int> EnrolledCourseIds { get; set; }
    public Dictionary<int, int> CourseProgress { get; set; }
    List<Enrollment> enrollments { get; set; } = new List<Enrollment>();
    public List<Course>EnrolledCourses= new List<Course>();
    public List<String> RecieveNotification(string message)
    {
       List<string> notifications = new List<string>();
    string notification = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
    notifications.Add(notification);
        Console.WriteLine(notification);
        return notifications;
    }

    public int ProgressPercentage{ get; set;  }
    private int progressPercentage
    {
        get { return ProgressPercentage; }
        set
        {
            if (value < 0 || value > 100)
            {
                Console.WriteLine("Error:Title must be 1-100 characters");
                return;
            }
            ProgressPercentage = value;
        }
    }

    public Student(string username, string password, string email) : base(username, password, email)
    {
        EnrolledCourseIds = new List<int>();
        CourseProgress = new Dictionary<int, int>();
    }
    public override string GetUserType()
    {
        return "Student";
    }
    public override void DisplayInfo()
    {
            base.DisplayInfo();
        Console.WriteLine($"enrolled courses;{enrollments.Count}");
    }
    public List<int>GetCompletedCourses()
    {
        List<int> completedCourses = new List<int>();
        foreach (var courseId in EnrolledCourseIds)
        {
            if (CourseProgress.ContainsKey(courseId) && CourseProgress[courseId] == 100)
            {
                completedCourses.Add(courseId);
            }
        }
        return completedCourses;
    }
    public double GetAverageProgress()
    {
        if (EnrolledCourseIds.Count == 0)
        {
            return 0.0;
        }
        int totalProgress = 0;
        foreach (var courseId in EnrolledCourseIds)
        {
            if (CourseProgress.ContainsKey(courseId))
            {
                totalProgress += CourseProgress[courseId];
            }
        }
        return (double)totalProgress / EnrolledCourseIds.Count;
    }
    public void DropCourse(int courseId)
    {
        if (EnrolledCourseIds.Contains(courseId))
        {
            EnrolledCourseIds.Remove(courseId);
            CourseProgress.Remove(courseId);
            Console.WriteLine("✓ Successfully dropped the course!");
        }
        else
        {
            Console.WriteLine("❌ Not enrolled in this course!");
        }
    }
    public void EnrollInCourse(int courseId)
    {
        if (!EnrolledCourseIds.Contains(courseId))
        {
            EnrolledCourseIds.Add(courseId);
            CourseProgress[courseId] = 0; // Initialize progress to 0%
            Console.WriteLine("✓ Successfully enrolled!");
        }
        else
        {
            Console.WriteLine("❌ Already enrolled in this course!");
        }
    }
    public void ShowEnrolledCourses()
    {
        if (EnrolledCourseIds.Count == 0)
        {
            Console.WriteLine("No courses enrolled.");
            return;
        }
        Console.WriteLine("Enrolled Courses:");
        foreach (var courseId in EnrolledCourseIds)
        {
            int progress = CourseProgress[courseId];
            Console.WriteLine($"Course {courseId} → {progress}% completed");
        }
    }
    public void UpdateProgress(int courseId, int progressPercentage)
    {        }
    public void EnrollInCourses(int courseId)
    {
        if (!EnrolledCourseIds.Contains(courseId))
        {
            EnrolledCourseIds.Add(courseId);
            CourseProgress[courseId] = 0; // Initialize progress to 0%
            Console.WriteLine("✓ Successfully enrolled!");
        }
        else
        {
            Console.WriteLine("❌ Already enrolled in this course!");
        }
    }
    public override void DisplayDashboard()
    {
        List<Enrollment> enrollments = new List<Enrollment>();
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("||      STUDENT DASHBOARD             ||");
        Console.WriteLine($"Welcome:{Username}");
        Console.WriteLine($"Enrolled Courses:{enrollments.Count}");
        Console.WriteLine("                                        ");
        Console.WriteLine("[1] Browse Courses");
        Console.WriteLine("[2] My Enrolled Courses");
        Console.WriteLine("[3] Update Progress");
        Console.WriteLine("[4] My Statistics");
        Console.WriteLine("[5] Logout");

    }
    public  bool MatchesSearch(string keyword)
    { 
        return Username.Contains(keyword,StringComparison.OrdinalIgnoreCase) || Email.ToLower().Contains(keyword.ToLower());
    } 
    public  string GetSearchSummary()
    {
                return $"[Student]{Username}{Email}-{EnrolledCourses.Count}courses";
    }
    private List<string>notifications=new List<string>();
    public void SendNotification(string message)
    {
        string notificattion = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]{message}";
        notifications.Add(notificattion);
        Console.WriteLine(notificattion);
    }
    
    public List <string>GetNotificationHistory()
    { 
        return new List<string>(notifications) ;
            
    }
    
}