
namespace project;

class Program
{
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
                    SearchCourse();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }



        string[] courses = {
    "C# Programming Fundamentals",
    " Introdeuction to SQL server",
    "Web Development with ASP.NET Core",
    "Advanced C# Techniques",
    "Database Design and Management",
    "RESTful API Development",
    "Entity Framework Core",
    "Front-end Development with Blazor",
    "Cloud Computing with Azure",
    "Software Testing and Quality Assurance"
};
        for (int i = 0; i < courses.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {courses[i]}");
        }

        static void SearchCourse()

        {
            Console.Write("Enter course name to search:");
            string keyword = Console.ReadLine();

            {
                if (Courses.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    Console.WriteLine($"Course '{keyword}' found in the catalog.");



                else
                    Console.WriteLine($"Course '{keyword}' not found in the catalog.");
            }
        }


        static void Register()
        {
            Console.Write("Enter username:");
            string username = Console.ReadLine();
            Console.Write("Enter password");
            string password = Console.ReadLine();
            Console.Write("Enter role:(Student/Instructor/Admin)");
            string role = Console.ReadLine();
            {
                switch (role)
                {
                    case "student":
                        Console.WriteLine("student"); break;
                    case "Instructor":
                        Console.WriteLine("Instructor"); break;
                    case "Admin":
                        Console.WriteLine("Admin"); break;
                    default:
                        Console.WriteLine("not valid"); break;
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
            static void Browsecourse()
            {
                string[] courses = {
            "C# Programming Fundamentals",
            " Introdeuction to SQL server",
            "Web Development with ASP.NET Core",
            "Advanced C# Techniques",
            "Database Design and Management",
            "RESTful API Development",
            "Entity Framework Core",
            "Front-end Development with Blazor",
            "Cloud Computing with Azure",
            "Software Testing and Quality Assurance" };
            }

        }
    }
}       