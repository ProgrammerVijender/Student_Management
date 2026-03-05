using System;
using System.Collections.Generic;

class Student
{
    public int Id;
    public string Name;
    public int Age;
    public string Course;

    public Student(int id, string name, int age, string course)
    {
        Id = id;
        Name = name;
        Age = age;
        Course = course;
    }
}

class StudentManagementSystem
{
    static List<Student> students = new List<Student>();
    static int nextId = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== STUDENT MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Choose option: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    ViewStudents();
                    break;
                case 3:
                    SearchStudent();
                    break;
                case 4:
                    DeleteStudent();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Course: ");
        string course = Console.ReadLine();

        students.Add(new Student(nextId++, name, age, course));
        Console.WriteLine("Student Added Successfully!");
    }

    static void ViewStudents()
{
    if (students.Count == 0)
    {
        Console.WriteLine("No students found.");
        return;
    }

    Console.WriteLine("\n{0,-5} {1,-15} {2,-5} {3,-15}", 
                      "ID", "Name", "Age", "Course");

    Console.WriteLine(new string('-', 45));

    foreach (var s in students)
    {
        Console.WriteLine("{0,-5} {1,-15} {2,-5} {3,-15}", 
                          s.Id, s.Name, s.Age, s.Course);
    }
}

    static void SearchStudent()
    {
        Console.Write("Enter Student ID to search: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var student = students.Find(s => s.Id == id);

        if (student != null)
        {
            Console.WriteLine($"Found: {student.Name}, Age: {student.Age}, Course: {student.Course}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void DeleteStudent()
    {
        Console.Write("Enter Student ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var student = students.Find(s => s.Id == id);

        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student Deleted Successfully!");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}