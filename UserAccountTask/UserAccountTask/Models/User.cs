using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccountTask.Interfaces;
using UserAccountTask.Exceptions;

namespace UserAccountTask.Models
{
    public class User : IAccount
    {
        private static int _userIdCounter;

        public int Id { get; private set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        static User()
        {
            _userIdCounter = 0;
        }

        private User()
        {
            Id = ++_userIdCounter;
        }

        public User(string email, string password, string fullName) : this()
        {
            Email = email;
            if (PasswordChecker(password))
            {
                Password = password;
            }
            else
            {
                throw new PasswordIsInvalidException("Password is not valid!");
            }
            FullName = fullName;
        }

        public bool PasswordChecker(string password)
        {
            bool passwordContainsUpper = false;
            bool passwordContainsLower = false;
            bool passwordContainsNumber = false;
            bool passwordIsValid = false;

            if(password.Length >= 8)
            {
                foreach (char character in password)
                {
                    if (char.IsUpper(character))
                    {
                        passwordContainsUpper = true;
                        break;
                    }
                }

                foreach (char character in password)
                {
                    if (char.IsLower(character))
                    {
                        passwordContainsLower = true;
                        break;
                    }
                }

                foreach (char character in password)
                {
                    if (char.IsDigit(character))
                    {
                        passwordContainsNumber = true;
                        break;
                    }
                }

                if (passwordContainsUpper == true && passwordContainsLower == true && passwordContainsNumber == true)
                {
                    passwordIsValid = true;
                }
                else
                {
                    throw new PasswordIsInvalidException("Password must be contain at least one upper character, one lower character and one digit!");
                }
            }
            else
            {
                throw new PasswordIsInvalidException("Password must be contain 8 symbol!");
            }
            return passwordIsValid;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id} - Full name: {FullName} - E-mail: {Email}");
        }
    }
}
