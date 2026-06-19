using System.Diagnostics.Tracing;

namespace project;


class Program
{
    static Dictionary<string, string> user = new Dictionary<string, string>();
    static Dictionary<string, string> usera = new Dictionary<string, string>();
    static void Main(string[] args)
    {




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
                    Console.WriteLine("Login Feature coming soon");
                    break;
                case "2":
                    Console.WriteLine("Register feature coming soon");
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



    static readonly string[] courses = {
      "C# Programming Fundamentals",
       " Introdeuction to SQL server",
        "Web Development with ASP.NET Core",
        "Advanced C# Techniques",
        "Database Design and Management",
       "RESTful API Development",
        "Entity Framework Core",
        "Front-end Development with Blazor",
        "Cloud Computing with Azure",
        "Software Testing and Quality Assurance"};


    static void Printcourses()
    {
        Console.Write("===Enter Available Courses===");
        for (int i = 0; i < courses.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {courses[i]}");
        }
        Searchcourses();
    }


    static void Register()
    {
        Console.Write("Enter username:");
        string username = Console.ReadLine();
        Console.Write("Enter password");
        string password = Console.ReadLine();
        Console.Write("Enter gmail:");
        string gmail = Console.ReadLine();
        Console.Write("Enter role:(Student/Instructor/Admin)");
        string role = Console.ReadLine();
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
                    user.Add(username, password);
                    usera.Add(gmail, role);

            }
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
        Console.Write("Enter password:");
        string password = Console.ReadLine();
        Console.Write("Enter role");
        string role = Console.ReadLine();
        Console.Write("Enter session state : (isloggedin/currentUser/currentROLE)");
        string sessionState = Console.ReadLine();
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



































    