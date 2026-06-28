using SmartLearn;
using System.Diagnostics.Tracing;
using System.Reflection;

namespace project;


class Program
{
    static List<User> users = new List<User>();
    static List<Course> courses = new List<Course>();
    static List<Enrollment> enrollments = new List<Enrollment>();

    static void Main(string[] args)
    {
        courses.Add(new course(1, "C# Programming Fundamentals", "Learn the basics of C#", "Prof.Smith", 30, 0, "Programming"));
        courses.Add(new Course(2, "Introduction to SQL Server", "Learn SQL Server basics", "Prof.Johnson", 25, 0, "Database"));
        courses.Add(new Course(3, "Web Development with ASP.NET Core", "Build web applications using ASP.NET Core", "Prof.Williams", 20, 0, "Web Development"));
        courses.Add(new Course(4, "Advanced C# Techniques", "Explore advanced C# programming concepts", "Prof.Brown", 15, 0, "Programming"));
        courses.Add(new Course(5, "Database Design and Management", "Learn database design principles", "Prof.Jones", 30, 0, "Database"));
        bool running = true;
        while (running)
            running = ShowMainMenu();
    }
    static bool ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("====================================");
        Console.WriteLine("Welcome to SmartLearn LMS");
        Console.WriteLine("====================================");
        Console.WriteLine("1.Login");
        Console.WriteLine("2.Register");
        Console.WriteLine("3.Browse Courses");
        Console.WriteLine("4.Exit");
        Console.Write("Enter your choice:");
        string userInput = Console.ReadLine();
        {

            switch (userInput)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Register();
                    break;
                case "3":
                    Printcourses();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }



 
    


        static void Printcourses()
    {
        Console.Write("===Enter Available Courses===");
        for (int i = 0; i < Courses.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Courses[i]}");
        }
        Searchcourses();
    }
    static void Register()
    {
        Console.WriteLine("===Register===");
        Console.Write("Enter username:");
        string username = Console.ReadLine();
        if (username != null)
        {
            validateusername(username);
        }
        Console.Write("Enter password");
        string password = Console.ReadLine();
        if (password.Length < 6)
        {
            vaildatepassword(password);
        }
        Console.Write("Enter email:");
        string email = Console.ReadLine();
        if (email != null)
        {
            validateemail(email);
        }
        Console.Write("Enter role:(student/Instructor/Admin)");
        string role = Console.ReadLine();
        if (role != "student" && role != "Instructor" && role != "Admin")
        {
            Console.WriteLine("Invaild role.please choose from student,Instructoror admin");
            return;
        }

        users.Add(new User(username, password,email,role));
        courses.Add(new course(Title));
    }
    static void validateusername(string username)
    {
        if (users.Contains(username))
        {
            Console.WriteLine("Username already exists. Please choose a different username.");
            Console.WriteLine("Enter newusername:");
            string newUsername = Console.ReadLine();
        }
    }
    static void vaildatepassword(string password)
    {
        if (password.Length < 6)
        {
            Console.WriteLine("Password must be at least 6 characters long.");
            Console.WriteLine("Enter new password:");
            string newPassword = Console.ReadLine();
        }
    }
    static void validateemail(string email)
    {
        if (users.Containskey(email))
        {
            Console.WriteLine("email already exits.Please choose a different email");
            Console.WriteLine("Enter new email");
            string newEmail = Console.ReadLine();
        }
    }
    static void Searchcourses()
    {
        Console.WriteLine("Enter Search Keyword");
        string keyword = Console.ReadLine();
        int browsecounter = 0;
        bool found = false;
        if (keyword != null) ;
        {
            Console.WriteLine("Courses found:");
            foreach (var course in courses)
            {
                if (course.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ;
                {
                    browsecounter++;
                    Console.WriteLine($"{browsecounter}.{course}");
                    found = true;
                }
                if (!found) ;
                {
                    Console.WriteLine("No courses matching the keyword.");
                }
                Console.WriteLine("Would you try again?(y/n) ");
                string tryagain = Console.ReadLine();
                switch (tryagain)
                {
                    case "y":
                        Searchcourses();
                        break;
                    case "n":
                        break;
                    default:
                        break;
                }
            }
        }
    }
    static void Login()
    {
        Console.Write("Enter username:");
        string username = Console.ReadLine();
        User foundUser = users.Find(u =>u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (foundUser == null)
        {
            Console.WriteLine("Username not found. Please register first.");
            return;
        }
        Console.Write("Enter password:");
        string password = Console.ReadLine();
        if (foundUser.ValidatePassword(password)) ;
        { isLoggedIn = true; }
        Console.Write("Enter role");
        string role = Console.ReadLine();
        Console.Write("Enter session state : (isloggedin/currentUser/currentROLE)");
        string sessionState = Console.ReadLine();
        {
            switch (role)
            {
                case "student":
                    showstudentdashboard();
                    break;
                case "Instructor":
                    showinstructordashboard();
                    break;
                case "Admin":
                    showadmindashboard();
                    break;
                default:
                    Console.WriteLine("not valid"); break;
            }
        }
        static void showstudentdashboard()
        {
            Console.WriteLine("================================");
            Console.WriteLine("Welcome to the Student Dashboard");
            Console.WriteLine("================================");
            Console.WriteLine("1.BrowseCourses");
            Console.WriteLine("2.My Course");
            Console.WriteLine("3.Progress");
            Console.WriteLine("4.Take Quiz ");
            Console.WriteLine("5.Logout");
            Console.Write("Enter your choice:");
            string studentChoice = Console.ReadLine();
            {
                switch (studentChoice)
                {
                    case "1":
                        Printcourses();
                        break;
                    case "2":
                        Console.WriteLine("My Course feature coming soon");
                        break;
                    case "3":
                        Console.WriteLine("Progress feature coming soon");
                        break;
                    case "4":
                        Console.WriteLine("Take Quiz feature coming soon");
                        break;
                    case "5":
                        Console.WriteLine("Logout feature coming soon");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.Please choose from 1-5");
                        break;
                }
            }

        }
        static void showinstructordashboard()
        {
            Console.WriteLine("================================");
            Console.WriteLine("Welcome to the Instructor Dashboard");
            Console.WriteLine("================================");
            Console.WriteLine("1.My Course");
            Console.WriteLine("2.Create Course");
            Console.WriteLine("3.View Student Progress");
            Console.WriteLine("4.Grade Assignments");
            Console.WriteLine("5.Logout");
            Console.Write("Enter your choice:");
            string instructorChoice = Console.ReadLine();
            {
                switch (instructorChoice)
                {
                    case "1":
                        Console.WriteLine("My Course feature coming soon");
                        break;
                    case "2":
                        Console.WriteLine("Create Course feature coming soon");
                        break;
                    case "3":
                        Console.WriteLine("View Student Progress feature coming soon");
                        break;
                    case "4":
                        Console.WriteLine("Grade Assignments feature coming soon");
                        break;
                    case "5":
                        Console.WriteLine("Logout feature coming soon");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.Please choose from 1-5");
                        break;
                }
            }
        }
        static void showadmindashboard()
        {
            Console.WriteLine("================================");
            Console.WriteLine("Welcome to the Admin Dashboard");
            Console.WriteLine("================================");
            Console.WriteLine("1.Manage Users");
            Console.WriteLine("2.Manage Courses");
            Console.WriteLine("3.View Reports");
            Console.WriteLine("4.Logout");
            Console.Write("Enter your choice:");
            string adminChoice = Console.ReadLine();
            {
                switch (adminChoice)
                {
                    case "1":
                        Console.WriteLine("Manage Users feature coming soon");
                        break;
                    case "2":
                        Console.WriteLine("Manage Courses feature coming soon");
                        break;
                    case "3":
                        Console.WriteLine("View Reports feature coming soon");
                        break;
                    case "4":
                        Console.WriteLine("Logout feature coming soon");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.Please choose from 1-4");
                        break;
                }
            }
        }
        bool isLoggedIn = false;

        static void logout()
        {
            Console.WriteLine("isLoggedIn=False");
            Console.WriteLine("currentUser=''");
            Console.WriteLine("currentRole=''");
        }
        static void exit()
        {
            Console.WriteLine("Exiting the application...");
        }
    }
}



































    