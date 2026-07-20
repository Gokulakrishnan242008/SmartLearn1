using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SmartLearn
{


    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            //Role = role;
            IsActive = true;
            DateRegistered = DateTime.Now;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Password:{Password}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Role: {Role}");
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


    }
}