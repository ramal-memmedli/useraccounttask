using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccountTask.Exceptions;

namespace UserAccountTask.Models
{
    public class Group
    {
        private static int _studentLimit;

        public string GroupNo { get; set; }
        public int StudentLimit { get { return _studentLimit; } set { if (value >= 5 && value <= 18) _studentLimit = value; } }

        private static List<Student> _students = new List<Student>();

        private Group()
        {

        }

        public Group(string groupNo, int studentLimit)
        {   
            GroupNo = groupNo;
            StudentLimit = studentLimit;
        }

        public static void CreateGroupByConsole()
        {
            Console.WriteLine("-------------------------------------------\n" +
                             $"------------- Create new group ------------\n" +
                              "-------------------------------------------");
            string groupNoInput = Program.GetStringInputByConsole("group number");
            string groupNo = null;
            if (CheckGroupNo(groupNoInput))
            {
                groupNo = groupNoInput;
            }
            else
            {
                throw new GroupNoIsNotValidException("Group number is not valid");
            }
            int studentLimitInput = Program.GetIntInputByConsole("student limit");
            int? studentLimit = null;
            if(studentLimitInput >= 5 && studentLimitInput <= 18)
            {
                studentLimit = studentLimitInput;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Student limit must be between 5 and 18");
            }
            Group group = new Group(groupNo, (int) studentLimit);

            Console.WriteLine("-------------------------------------------\n" +
                             $"--- Group must contain minimum 5 student --\n" +
                              "-------------------------------------------");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("-------------------------------------------\n" +
                                 $"------------- Add new student -------------\n" +
                                  "-------------------------------------------");
                string fullName = Program.GetStringInputByConsole("full name");
                double point = Program.GetDoubleInputByConsole("point");
                Student student = new Student(fullName, point);
                AddStudent(student);
            }


            Console.WriteLine("-------------------------------------------\n" +
                             $"-------- Group successfully created -------\n" +
                              "-------------------------------------------");
        }

        public static bool CheckGroupNo(string groupNo)
        {
            bool groupNoFirstPartIsValid = false;
            bool groupNoIsValid = false;

            int numberCounter = 0;

            char character;
            if(groupNo != null)
            {
                if(groupNo.Length == 5)
                {
                    if(groupNo[0].ToString().ToLower() != groupNo[0].ToString() && groupNo[1].ToString().ToLower() != groupNo[1].ToString())
                    {
                        groupNoFirstPartIsValid = true;
                    }
                    else
                    {
                        throw new GroupNoIsNotValidException("Group number is not valid");
                    }
                    for (int i = 2; i < groupNo.Length; i++)
                    {
                        character = groupNo[i];
                        if (char.IsDigit(character))
                        {
                            numberCounter++;
                        }
                    }
                    if(groupNoFirstPartIsValid == true && numberCounter == 3)
                    {
                        groupNoIsValid = true;
                    }
                    else
                    {
                        throw new GroupNoIsNotValidException("Group number is not valid");
                    }
                }
                else
                {
                    throw new GroupNoIsNotValidException("Group number must be contain 5 symbol");
                }
            }
            else
            {
                throw new NullReferenceException("Group name can't be null");
            }
            return groupNoIsValid;
        }

        public static void AddStudent(Student student)
        {
            if(_students.Count < _studentLimit)
            {
                _students.Add(student);
            }
            else
            {
                throw new StudentLimitExceededException("Student limit exceeded!");
            }
        }

        public static Student CreateStudentByConsole()
        {
            Console.WriteLine("-------------------------------------------\n" +
                                 $"------------- Add new student -------------\n" +
                                  "-------------------------------------------");
            string fullName = Program.GetStringInputByConsole("full name");
            double point = Program.GetDoubleInputByConsole("point");
            Student student = new Student(fullName, point);
            return student;
        }

        public static Student GetStudent(int? id)
        {
            return _students.Find(x => x.Id == id);
        }

        public static void GetStudentInfo(Student student)
        {
            student.StudentInfo();
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public static void AllStudentsInfo()
        {
            if(_students.Count > 0)
            {
                foreach (Student student in _students)
                {
                    student.StudentInfo();
                }
            }
            else
            {
                Console.WriteLine("-------------------------------------------\n" +
                                 $"------ There are no students in group -----\n" +
                                  "-------------------------------------------");
            }
        }
    }
}
