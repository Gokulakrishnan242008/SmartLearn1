using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SmartLearn
{


    public abstract class User
    {
        public string Username { get; set; }
        private string Password { get; set; }
        public string password 
        {
            get { return Password; }
            set
            {
                if(value==null||value.Length<8)
                {

                    Console.WriteLine("Error:Password must be at leastv * characters long.");
                    return;
                }
                if (!value.Any(char.IsDigit))
                {
                    Console.WriteLine("Error:Password must contain at least 1 digit.");
                    return;
                }
                password= value;
            }

        }
        private string email;
        public string Email 
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
            {
                    Console.WriteLine("Error:Email cannot be empty.");
                    return;
            }
                if(!value.Contains("@"))
                {
                    Console.WriteLine("Error:Email must contain'@'.");
                    return;
                }
                email= value;
            }
        }

        //public string Role { get; set; }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            //Role = role;
            IsActive = true;
            DateRegistered = DateTime.Now;
        }
        

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Password:{Password}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Department")
       /*     Console.WriteLine($"Role: {Role}")*/;
            Console.WriteLine($"IsActive:{IsActive}");
            Console.WriteLine($"DateRegistered:{DateRegistered}");
        }

        public bool IsActive { get; set; }
        public DateTime DateRegistered { get; set; }

        string newPassword { get; set; }
        public bool ValidatePassword(string password)
        {
            return Password == password;
        }
        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
            Console.WriteLine("Password changed successfully");

        }

        public void Deactive()
        {
            IsActive = false;
            Console.WriteLine("Account deactivated)");
        }
        public abstract void DisplayDashboard();
        public abstract string GetUserType();

    }
}