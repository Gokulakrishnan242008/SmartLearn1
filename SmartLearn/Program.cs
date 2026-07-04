using SmartLearn;
using System.Diagnostics.Tracing;
using System.Reflection;

namespace project;


class Program
{
    static List<User> users = new List<User>();
    static List<Course> courses = new List<Course>();
    static List<Enrollment> enrollments = new List<Enrollment>();
    static bool isLoggedIn = false;
    static User currentUser = null;
    
    static void Main(string[] args)
    {
        courses.Add(new Course(1, "C# Programming Fundamentals", "Learn the basics of C#", "Prof.Smith", 30, 0, "Programming"));
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
                case "1": Login();break;
                case "2":Register();break;
                case "3": BrowseAndEnrollCourses();break;
                default:Console.WriteLine("Invalid choice");break;
            }
            return true;
        }
    static void Register()
    {
        Console.WriteLine("===Register===");
        Console.Write("Enter username:");
        string username = Console.ReadLine();
        if (username != null)
        {
           if(users.Exists(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Username already exists. Please choose a different username.");
                    return;
                }
        }
        Console.Write("Enter password");
        string password = Console.ReadLine();
        if (password!=null )
        {
            if(password.Length < 6)
                {
                    Console.WriteLine("Password must be at least 6 characters long.");
                    return;
                }
        }
        Console.Write("Enter email:");
        string email = Console.ReadLine();
            if (email != null)
            {
                if (users.Exists(u => u.Email == email))
                {
                    Console.WriteLine("Email already exists. Please choose a different email.");
                    return;
                }
            }
        Console.Write("Enter role:(student/Instructor/Admin)");
        string role = Console.ReadLine();
        if (role != "student" && role != "Instructor" && role != "Admin")
        {
            Console.WriteLine("Invaild role.please choose from student,Instructoror admin");
            return;
        }

     
        
    }
    
    
    static void Login()
    {
            Console.Write("Enter username:");
            string username = Console.ReadLine();
            if(string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Username cannot be empty.");
                return;
            }
            if (!users.Exists(u => u.Username == username))
            {
                Console.WriteLine("Username does not exist. Please register first.");
                return;
            }
            Console.Write("Enter password:");
            string password = Console.ReadLine();
            if(password == null)
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }
            User checkpass = users.Find(u => u.Username == username);
            if (checkpass == null)
            {
                Console.WriteLine("Username does not exist. Please register first.");
                return;
            }

            bool get = checkpass.ValidatePassword(password);
            if (get)
            {
                bool isLoggedIn = true;
                currentUser = checkpass;
                Console.WriteLine("Welcome, " + currentUser.Username + "! You have successfully logged in as a " + currentUser.Role + ".");
            }
            else
            {
                Console.WriteLine("Incorrect password. Please try again.");
            }

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
    }
            static void LoadSampleCourses()
         { 
               courses.Add(new Course(1, "C# Programming Fundamentals", "Learn the basics of C#", "Prof.Smith", 30, 0, "Programming"));
            courses.Add(new Course(2, "Introduction to SQL Server", "Learn SQL Server basics", "Prof.Johnson", 25, 0, "Database"));
            courses.Add(new Course(3, "Web Development with ASP.NET Core", "Build web applications using ASP.NET Core", "Prof.Williams", 20, 0, "Web Development"));
            courses.Add(new Course(4, "Advanced C# Techniques", "Explore advanced C# programming concepts", "Prof.Brown", 15, 0, "Programming"));
            courses.Add(new Course(5, "Database Design and Management", "Learn database design principles", "Prof.Jones", 30, 0, "Database"));
         }
        
        static void BrowseAndEnrollCourses()
        {
            LoadSampleCourses();
            Console.WriteLine("=============");
            Console.WriteLine("Available courses");
            Console.WriteLine("=============");
            foreach (var course in courses)
            {
                Console.WriteLine("===========================");
                Console.WriteLine(course.CourseId + ".");
                Console.WriteLine(course.Title + " ");
                Console.WriteLine("**" + course.Description);
                Console.WriteLine("Instructor:" + course.InstructorName);
                Console.WriteLine("number of students enrolled:" + course.MaxStudents);
                Console.WriteLine("==============================");
            }
            Console.WriteLine("Enter the number of courses you wanted to enroll in:");
            int courseId = Convert.ToInt32(Console.ReadLine());
            if (courseId > 5)
            {
                Console.WriteLine("incorrect course number.Please enter valid course number from the list");
            }
            Course obj = courses.Find(c => c.CourseId == courseId);
            bool c1 = obj.CanEnroll();
            if (users.Exists(e => e.Username == currentUser.Username && e.Role == "Student"))
            {
                if (c1 == false)
                {
                    Console.WriteLine("Sorry, There are no available seats in this course. Please choose a different course.");
                }
                else
                {
                    int enrollmentid = enrollments.Count + 1;
                    obj.IncrementEnrollment();
                    Enrollment enrollment = new Enrollment(enrollmentid,"StudentUsername","courseTitle",courseId,false);
                    enrollments.Add(enrollment);
                    Console.WriteLine("You have successfully enrolled in the course: " + obj.Title);
                }
            }
            else
            {
                Console.WriteLine("You must be logged in as a student to enroll in courses. Please log in or register as a student to continue.");
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



































    