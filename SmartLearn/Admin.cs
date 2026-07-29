using SmartLearn;
using System;
using System.Collections.Generic;
using System.Text;

public abstract class Admin : User
{
    bool CanManageUsers;
    bool CanManageCourses;
    string AdminLevel;
    public Admin(string username, string password, string email) : base(username, password, email)
    {
        CanManageUsers = true;
        CanManageCourses = true;
        AdminLevel = "Super";
    }
    public override string GetUserType()
    {
        return "Admin";
    }
    public override void DisplayInfo()
    {
            base.DisplayInfo();
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
    public void GetSystemStats(List<User> users, List<Course> courses)
    {
        int totalUsers = users.Count;
        int totalCourses = courses.Count;
        Console.WriteLine("System Statistics:");
        Console.WriteLine($"Total Users: {totalUsers}");
        Console.WriteLine($"Total Courses: {totalCourses}");
    }
    public void DisplayPermissions()
    {
        Console.WriteLine("Admin Permissions:");
        Console.WriteLine($"Can Manage Users: {CanManageUsers}");
        Console.WriteLine($"Can Manage Courses: {CanManageCourses}");
    }
    public override void DisplayDashboard()
    {
        Console.WriteLine("");
        Console.WriteLine("       ADMIN DASHBOARD     ");
        Console.WriteLine("");
        Console.WriteLine($"Welcome,Admin {Username}");
        Console.WriteLine("Level: Super");
        Console.WriteLine("                          ");
        Console.WriteLine("[1] Manage Users");
        Console.WriteLine("[2] Manage Courses");
        Console.WriteLine("[3] View System Reports");
        Console.WriteLine("[4] System Settings");
        Console.WriteLine("[5] Logout");
    }
}

