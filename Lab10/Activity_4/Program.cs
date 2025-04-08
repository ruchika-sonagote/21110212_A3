// See https://aka.ms/new-console-template for more information
using System;

namespace OOPStudentDemo
{
    class Student
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public double Marks { get; set; }

        public Student(string name, int id, double marks)
        {
            Name = name;
            ID = id;
            Marks = marks;
        }

        public string GetGrade()
        {
            if (Marks >= 90)
                return "A";
            else if (Marks >= 75)
                return "B";
            else if (Marks >= 60)
                return "C";
            else if (Marks >= 45)
                return "D";
            else
                return "F";
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Marks: {Marks}");
            Console.WriteLine($"Grade: {GetGrade()}");
        }
    }

    class StudentIITGN : Student
    {
        public string Hostel_Name_IITGN { get; set; }

        public StudentIITGN(string name, int id, double marks, string hostel)
            : base(name, id, marks)
        {
            Hostel_Name_IITGN = hostel;
        }

        public new void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Hostel Name (IITGN): {Hostel_Name_IITGN}");
        }
    }

    class Program
    {
        static void Main()
        {
            // Base Student
            Student s1 = new Student("Ruchika", 101, 87.5);
            Console.WriteLine("Student Details:");
            s1.DisplayDetails();

            Console.WriteLine("\n---\n");

            // IITGN Student
            StudentIITGN s2 = new StudentIITGN("Anita", 202, 93.2, "A-Block");
            Console.WriteLine("IITGN Student Details:");
            s2.DisplayDetails();
        }
    }
}
