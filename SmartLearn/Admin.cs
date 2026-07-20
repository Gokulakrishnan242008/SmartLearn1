using SmartLearn;
using System;
using System.Collections.Generic;
using System.Text;

public class Admin : User
{
    bool CanManageUsers;
    bool CanManageCourses;
    public Admin(string username, string password, string email) : base(username, password, email)
    {
        CanManageUsers = true;
        CanManageCourses = true;
    }
    public void ViewAllUsers(List<User> users)
    {
        Console.WriteLine("All Users:");
        foreach (var user in users)
        {
            user.DisplayInfo();
            Console.WriteLine("--------------------");
        }
    }
    public void DeactivateUser(User user)
    {
        user.Deactive();
        Console.WriteLine($"User {user.Username} has been deactivated.");
    }
    public void GetSystemStats(List<User> users, List<Course> courses,List<Enrollment>enrollments)
    {
        int totalUsers = users.Count;
        int totalCourses = courses.Count;
        Console.WriteLine("System Statistics:");
        Console.WriteLine($"Total Users: {totalUsers}");
        Console.WriteLine($"Total Courses: {totalCourses}");
        Console.WriteLine($"Total Enrollments:{enrollments.Count}");
        Console.WriteLine("\n===== SYSTEM STATISTICS =====");

            Console.WriteLine($"Total Users           : {users.Count}");
            Console.WriteLine($"Total Students        : {users.Count(u => u is Student)}");
            Console.WriteLine($"Total Instructors     : {users.Count(u => u is Instructor)}");
            Console.WriteLine($"Total Courses         : {courses.Count}");
            Console.WriteLine($"Total Enrollments     : {enrollments.Count}");

            // Students with 100% completion rate
            int completedStudents = enrollments.Where(e => e.ProgressPercentage == 100).Select(e => e.StudentUsername).Distinct().Count();

            Console.WriteLine($"Students with 100% Completion : {completedStudents}");

            // Most popular course
            Course mostPopular = courses .OrderByDescending(c => c.CurrentEnrollments).FirstOrDefault();

            if (mostPopular != null)
            {
                Console.WriteLine($"Most Popular Course : {mostPopular.Title} ({mostPopular.CurrentEnrollments})");
            }

            // Least popular course
            Course leastPopular = courses.OrderBy(c => c.CurrentEnrollments).FirstOrDefault();

            if (leastPopular != null)
            {
                Console.WriteLine($"Least Popular Course : {leastPopular.Title} ({leastPopular.CurrentEnrollments} enrollments)");
            }

            // Inactive users count
            int inactiveUsers = users.Count(u => !u.IsActive);

            Console.WriteLine($"Inactive Users : {inactiveUsers}");
        
    }
    public void DisplayPermissions()
    {
        Console.WriteLine("Admin Permissions:");
        Console.WriteLine($"Can Manage Users: {CanManageUsers}");
        Console.WriteLine($"Can Manage Courses: {CanManageCourses}");
    }
}

