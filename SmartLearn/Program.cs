using SmartLearn;
using System.Diagnostics.Tracing;
using System.Reflection;

namespace project;


class Program
{
    static List<User> users = new List<User>();
    static List<Course> courses = new List<Course>();
    static List<Enrollment> enrollments = new List<Enrollment>();
     bool isLoggedIn = false;
    static User currentUser = null;

    static void Main(string[] args)
    {
        InitializeCourses();

        bool running = true;
        while (running)
        {
            running = ShowMainMenu();
        }
    }
    
    static void InitializeCourses()
    {
        courses.Add(new InPersonCourse(201, "Database Design Workshop", "Learn the basics of programming using C#", "John Smith", 25, 0, "Computer Science", 0, 101, "Room A"));
        courses.Add(new InPersonCourse(202, "Network Security Lab", "Practical Laboratory sessions covering network security", "John steve", 20, 0, "Web Development", 0, 205, "Room C"));
        courses.Add(new InPersonCourse(203, "Mobile App Development", "Learn the fundamentals of mobile application development ", "John keyn", 30, 0, "Web Development", 0, 301, "Room A"));
        courses.Add(new OnlineCourse(101, "C# Fundamentals", "Learn the Fundamentals of C# programming", "prof.smith", 20, 0, "Programming", 450, "https.//smartLearn.com/stream", "Unlimited"));
        courses.Add(new OnlineCourse(102, "Python for Beginners", "Learn Python programming from the basics.", "Prof. Johnson", "Programming", 360));
        courses.Add(new OnlineCourse(103, "Web Development Basics", "Learn the basics of HTML, CSS and web development.", "Prof. Williams", "Web Development", 540));
        courses.Add(new OnlineCourse(104, "Data Structures", "Learn arrays, lists, stacks, queues and other data structures.", "Prof. Brown", "Computer Science", 600));
        courses.Add(new OnlineCourse(105, "Machine Learning Intro", "Introduction to machine learning concepts and techniques.", "Prof. Davis", "Machine Learning", 720));
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
        static void UniversalSearch(List<Course> courses, List<User> users)
        {
            List<ISearchable> searchableItems = new List<ISearchable>();
            foreach (Course course in courses)
            {
                searchableItems.Add(course);
            }

            foreach (User user in users)
            {
                if (user is ISearchable searchableusers)
                {
                    searchableItems.Add(searchableusers);
                }
            }
            Console.WriteLine("Enter Search keyword=");
            string keyword = Console.ReadLine();
            List<ISearchable> results = SearchEngine.Search(searchableItems, keyword);
            SearchEngine.DisplayResults(results);
            
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
        Console.Write("Enter password:");
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
        Console.Write("Enter role:(student/Instructor/Admin):");
        string role = Console.ReadLine();
            if (role != "student" && role != "Instructor" && role != "Admin")
            {
                Console.WriteLine("Invaild role.please choose from student,Instructoror admin");
                return;
            }

            //if (role.Equals("Student", StringComparison.OrdinalIgnoreCase))
            //{
            //    Student student = new Student(username, password, email);
            //}
            //else if(role.Equals("Instructor",StringComparsion.OrdinalIgnoreCase))
            //{
            //    Instructor instructor= new Instructor(username, password, email);
            //}



    }
    
    
    static void Login()
    {
            Console.Write("Enter username:");
            string username = Console.ReadLine();
            Console.Write("Enter password:");
            string password = Console.ReadLine();
            Console.Write("Enter email:");
            string email = Console.ReadLine();
            Console.Write("Enter role:");
            string role = Console.ReadLine();
        
       
           bool isLoggedIn =true;
            if (isLoggedIn)
            {
                currentUser.DisplayDashboard();
            }
         
                
            
    }
         //   static void LoadSampleCourses()
         //{
         //   courses.Clear();
         //   courses.Add(new Course(1, "C# Programming Fundamentals", "Learn the basics of C#", "Prof.Smith", 30, 0, "Programming"));
         //   courses.Add(new Course(2, "Introduction to SQL Server", "Learn SQL Server basics", "Prof.Johnson", 25,0 , "Database"));
         //   courses.Add(new Course(3, "Web Development with ASP.NET Core", "Build web applications using ASP.NET Core", "Prof.Williams", 20, 0, "Web Development"));
         //   courses.Add(new Course(4, "Advanced C# Techniques", "Explore advanced C# programming concepts", "Prof.Brown", 15, 0, "Programming"));
         //   courses.Add(new Course(5, "Database Design and Management", "Learn database design principles", "Prof.Jones", 30, 0, "Database"));
         //   Console.WriteLine("✓ Sample courses loaded successfully!");
         //}
        
        static void BrowseAndEnrollCourses()
        {
         
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
            if (users.Exists(e => e.Username == currentUser.Username ))
            {
                if (c1 == false)
                {
                    Console.WriteLine("Sorry, There are no available seats in this course. Please choose a different course.");
                }
                else
                {
                    int enrollmentid = enrollments.Count + 1;
                    obj.IncrementEnrollment();
                    Enrollment enrollment = new Enrollment(enrollmentid, "StudentUsername", "courseTitle", courseId, false);
                    enrollments.Add(enrollment);
                    Console.WriteLine("You have successfully enrolled in the course: " + obj.Title);
                }
            }
            else
            {
                Console.WriteLine("You must be logged in as a student to enroll in courses. Please log in or register as a student to continue.");
            }
            static void EnrollStudentInCourse(Student student)
            {
                Console.WriteLine("\n=== AVAILABLE COURSES ===");
                // Display all courses 
                foreach (Course course in courses)
                {
                    Console.WriteLine($"\n[{course.CourseId}] {course.Title}");
                    Console.WriteLine($"Category: {course.Category}");
                    Console.WriteLine($"Instructor: {course.InstructorName}");
                    Console.WriteLine($"Enrollment:{course.CurrentEnrollments}");
                    Console.WriteLine($"Available: {(course.CanEnroll() ? "✓Yes" : "✗ Full")}");
                    Console.WriteLine("---");
                }

                Console.Write("\nEnter Course ID to enroll: ");
                if (!int.TryParse(Console.ReadLine(), out int courseId))
                {
                    Console.WriteLine("  Invalid course ID.");
                    return;
                }

                // Find the course 
                Course selectedCourse = courses.Find(c => c.CourseId == courseId);

                if (selectedCourse == null)
                {
                    Console.WriteLine("  Course not found.");
                    return;
                }
                // Check if course can accept enrollments 
                if (!selectedCourse.CanEnroll())
                {
                    Console.WriteLine("  Course is full!");
                }
                return;
            }

            // Check if student already enrolled 
            if (student.EnrolledCourseIds.Contains(courseId))
            {
                Console.WriteLine("  Already enrolled in this course!");
                return;
            }

            // Enroll student 
            student.EnrollInCourse(courseId);

            // Update course enrollment count 
            Course seelectedCourse = courses.Find(c => c.CourseId == courseId);
            selectedCourse.IncrementEnrollment();

            // Create enrollment record 
            int enrollmentId = enrollments.Count + 1;
            Enrollment newEnrollment = new Enrollment(enrollmentId, "StudentUsername", "courseTitle",courseId, false);

            enrollments.Add(newEnrollment);

            Console.WriteLine($"✓ Successfully enrolled in '{selectedCourse.Title}'!");
        }
        static void UpdateStudentProgress(Student student)
        {
            student.ShowEnrolledCourses();

            Console.Write("\nEnter Course ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.WriteLine("  Invalid course ID.");
                return;
            }

            Console.Write("Enter progress percentage (0-100): ");
            if (!int.TryParse(Console.ReadLine(), out int ProgressPercentage) ||ProgressPercentage < 0 || ProgressPercentage > 100)
            {
                Console.WriteLine("  Invalid progress value.");
                return;
            }

            // Update student's progress
            student.UpdateProgress(courseId, ProgressPercentage);

            // Find and update enrollment record 
            Enrollment enrollment = enrollments.Find(e =>e.StudentUsername == student.Username && e.CourseId ==courseId);

            if (enrollment != null)
            {
                enrollment.UpdateProgress(ProgressPercentage);
                Console.WriteLine("✓ Progress updated!");
            }
        }

        static void DropStudentCourse(Student student)
        {
            student.ShowEnrolledCourses();

            Console.Write("\nEnter Course ID to drop: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.WriteLine("  Invalid course ID.");
                return;
            }

            // Drop from student 
            student.DropCourse(courseId);

            // Find the course and decrement enrollment 
            Course course = courses.Find(c => c.CourseId == courseId);
            if (course != null)
            {
                course.DecrementEnrollment();
            }
             // Remove enrollment record 
            Enrollment enrollment = enrollments.Find(e =>e.StudentUsername == student.Username && e.CourseId == courseId);

            if (enrollment != null)
            {
                enrollments.Remove(enrollment);
            }
        }

        static void ShowStudentStats(Student student)
        {
            Console.WriteLine("\n=== YOUR STATISTICS ===");
            Console.WriteLine($"Username: {student.Username}");
            Console.WriteLine($"Total Courses Enrolled:{ student.EnrolledCourseIds.Count}"); 
            Console.WriteLine($"Completed Courses: { student.GetCompletedCourses().Count}"); 
             Console.WriteLine($"Average Progress: { student.GetAverageProgress():F2}%"); 
             var completed = student.GetCompletedCourses(); 
            if (completed.Count > 0) 
             { 
                 Console.WriteLine("\nCompleted Courses:"); 
                   foreach (int courseId in completed) 
                    { 
                        Course course = courses.Find(c => c.CourseId == courseId); 
                         if (course != null) 
                          { 
                             Console.WriteLine($"  ✓ {course.Title}");
                         }
                    }
             }
        }

        static void AddInstructorCourse(Instructor instructor)
        {
            

            Console.Write("\nEnter Course ID to add: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.WriteLine("  Invalid course ID.");
                return;
            }

            Course course = courses.Find(c => c.CourseId == courseId);
            if (course == null)
            {
                Console.WriteLine("  Course not found.");
                return;
            }

            instructor.AddCourse(courseId);
        }
        static void ShowInstructorStudentCount(Instructor instructor)
        {
            int count = instructor.GetStudentCount(enrollments);
            Console.WriteLine($"\nTotal students in your courses: {count}");
        }

        static void DisplayAllCourses()
        {
            Console.WriteLine("\n=== ALL COURSES ===");
            foreach (Course course in courses)
            {
                Console.WriteLine($"\n[{course.CourseId}] {course.Title}");
                Console.WriteLine($"Category: {course.Category}");
                Console.WriteLine("---");
            }
        }

        static void DeactivateUserAsAdmin(Admin admin)
        {
            admin.ViewAllUsers(users);
            Console.Write("\nEnter username to deactivate: ");
            string username = Console.ReadLine();

            User userToDeactivate = users.Find(u => u.Username == username);

            if (userToDeactivate == null)
            {
                Console.WriteLine("  User not found.");
                return;
            }

            if (userToDeactivate == currentUser)
            {
                Console.WriteLine("  You cannot deactivate yourself!");
                return;
            }

            admin.DeactivateUser(userToDeactivate);
        }


        //static void showstudentdashboard(Student)
        //{
        //    Console.WriteLine("================================");
        //    Console.WriteLine("Welcome to the Student Dashboard");
        //    Console.WriteLine("================================");
        //    Console.WriteLine("1.BrowseCourse");
        //    Console.WriteLine("2.My Course");
        //    Console.WriteLine("3.Progress");
        //    Console.WriteLine("4.Take Quiz ");
        //    Console.WriteLine("5.Logout");
        //    Console.Write("Enter your choice:");
        //    string studentChoice = Console.ReadLine();
        //    {
        //        switch (studentChoice)
        //        {
        //            case "1":
        //                BrowseAndEnrollCourses();break;
        //             case "2":
        //                Console.WriteLine("My Course feature coming soon");
        //                break;
        //            case "3":
        //                Console.WriteLine("Progress feature coming soon");
        //                break;
        //            case "4":
        //                Console.WriteLine("Take Quiz feature coming soon");
        //                break;
        //            case "5":
        //                Console.WriteLine("Logout feature coming soon");
        //                break;
        //            default:
        //                Console.WriteLine("Invalid choice.Please choose from 1-5");
        //                break;
        //        }
        //    }

        //}
        //static void showinstructordashboard(Instructor)
        //{
        //    Console.WriteLine("================================");
        //    Console.WriteLine("Welcome to the Instructor Dashboard");
        //    Console.WriteLine("================================");
        //    Console.WriteLine("1.My Course");
        //    Console.WriteLine("2.Create Course");
        //    Console.WriteLine("3.View Student Progress");
        //    Console.WriteLine("4.Grade Assignments");
        //    Console.WriteLine("5.Logout");
        //    Console.Write("Enter your choice:");
        //    string instructorChoice = Console.ReadLine();
        //    {
        //        switch (instructorChoice)
        //        {
        //            case "1":
        //                Console.WriteLine("My Course feature coming soon");
        //                break;
        //            case "2":
        //                Console.WriteLine("Create Course feature coming soon");
        //                break;
        //            case "3":
        //                Console.WriteLine("View Student Progress feature coming soon");
        //                break;
        //            case "4":
        //                Console.WriteLine("Grade Assignments feature coming soon");
        //                break;
        //            case "5":
        //                Console.WriteLine("Logout feature coming soon");
        //                break;
        //            default:
        //                Console.WriteLine("Invalid choice.Please choose from 1-5");
        //                break;
        //        }
        //    }
        //}
        //static void showadmindashboard(Admin)
        //{
        //    Console.WriteLine("================================");
        //    Console.WriteLine("Welcome to the Admin Dashboard");
        //    Console.WriteLine("================================");
        //    Console.WriteLine("1.Manage Users");
        //    Console.WriteLine("2.Manage Courses");
        //    Console.WriteLine("3.View Reports");
        //    Console.WriteLine("4.Logout");
        //    Console.Write("Enter your choice:");
        //    string adminChoice = Console.ReadLine();
        //    {
        //        switch (adminChoice)
        //        {
        //            case "1":
        //                Console.WriteLine("Manage Users feature coming soon");
        //                break;
        //            case "2":
        //                Console.WriteLine("Manage Courses feature coming soon");
        //                break;
        //            case "3":
        //                Console.WriteLine("View Reports feature coming soon");
        //                break;
        //            case "4":
        //                Console.WriteLine("Logout feature coming soon");
        //                break;
        //            default:
        //                Console.WriteLine("Invalid choice.Please choose from 1-4");
        //                break;
        //        }
        //    }
        //}

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



































    