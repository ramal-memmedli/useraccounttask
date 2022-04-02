using System;
using UserAccountTask.Models;
using UserAccountTask.Exceptions;

namespace UserAccountTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("-------------------------------------------\n" +
                             $"------------- Create new user -------------\n" +
                              "-------------------------------------------");
            string fullName = GetStringInputByConsole("full name");
            string email = GetStringInputByConsole("e-mail");
            string password = GetStringInputByConsole("password");
            User user = new User(email, password, fullName);
            Console.WriteLine("-------------------------------------------\n" +
                             $"-------- User successfully created --------\n" +
                              "-------------------------------------------");

        MenuFirstPart:

            Console.WriteLine("-------------------------------------------\n" +
                              "\n" +
                              "1 - Show info\n" +
                              "2 - Create new group\n" +
                              "\n" +
                              "-------------------------------------------");

            int input = GetIntInputByConsole("input");

            switch (input)
            {
                case 1:
                    Console.Clear();
                    user.ShowInfo();
                    goto MenuFirstPart;
                case 2:
                    Console.Clear();
                    Group.CreateGroupByConsole();
                    goto MenuSecondPart;
            }
            Console.Clear();
        MenuSecondPart:

            

            Console.WriteLine("-------------------------------------------\n" +
                              "\n" +
                              "1 - Show all students\n" +
                              "2 - Get student by id\n" +
                              "3 - Add student\n" +
                              "\n" +
                              "-------------------------------------------");

            input = GetIntInputByConsole("input");

            switch (input)
            {
                case 1:
                    Console.Clear();
                    Group.AllStudentsInfo();
                    goto MenuSecondPart;
                case 2:
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------\n" +
                                     $"------------- Please enter id -------------\n" +
                                      "-------------------------------------------");
                    int id = GetIntInputByConsole("id");
                    Group.GetStudentInfo(Group.GetStudent(id));
                    goto MenuSecondPart;
                case 3:
                    Console.Clear();
                    Group.AddStudent(Group.CreateStudentByConsole());
                    goto MenuSecondPart;
                case 0:
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------\n" +
                                     $"-------------- Invalid input --------------\n" +
                                      "-------------------------------------------");
                    goto MenuSecondPart;

            }
        }

        public static string GetStringInputByConsole(string content)
        {
        ReEnterStringInput:
            Console.Write($"Please enter {content} : ");
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                 $"--------- {content} can't be empty! --------\n" +
                                  "-------------------------------------------");
                goto ReEnterStringInput;
            }

            return input;
        }

        public static int GetIntInputByConsole(string content)
        {
        ReEnterIntInput:

            Console.Write($"Please enter {content} : ");
            string inputString = Console.ReadLine().Trim().ToLower();
            int? input;

            try
            {
                input = Convert.ToInt32(inputString);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                  $"------- {content} must be digit! ------\n" +
                                  "-------------------------------------------");
                goto ReEnterIntInput;
            }

            return (int)input;
        }

        public static double GetDoubleInputByConsole(string content)
        {
        ReEnterIntInput:

            Console.Write($"Please enter {content} : ");
            string inputString = Console.ReadLine().Trim().ToLower();
            double? input;

            try
            {
                input = Convert.ToDouble(inputString);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                  $"------- {content} must be digit! ------\n" +
                                  "-------------------------------------------");
                goto ReEnterIntInput;
            }

            return (double) input;
        }
    }
}
