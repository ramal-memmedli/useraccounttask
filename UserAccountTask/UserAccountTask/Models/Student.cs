using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccountTask.Models
{
    public class Student
    {
        private static int _studentIdCounter;
        private double _point;

        public int Id { get; private set; }
        public string FullName { get; set; }
        public double Point { get { return _point; } set { if (value > 0.0 && value < 100.0) _point = value; } }

        static Student()
        {
            _studentIdCounter = 0;
        }

        private Student()
        {
            Id = ++_studentIdCounter;
        }

        public Student(string fullName, double point) : this()
        {
            FullName = fullName;
            Point = point;
        }

        public void StudentInfo()
        {
            Console.WriteLine($"Id: {Id} - Full name: {FullName} - Point: {Point}");
        }
    }
}
