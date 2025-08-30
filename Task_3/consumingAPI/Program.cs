using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using StudentConsoleApp;

namespace StudentApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new StudentService();

            string endpoint = "https://students.innopack.app/api/students";

            await service.InitializeDataAsync(endpoint);

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add a student");
                Console.WriteLine("2. Show students");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    var students = service.LoadStudents();

                    Student newStudent = new Student();
                    Console.Write("Enter ID: ");
                    newStudent.Id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    newStudent.Name = Console.ReadLine();

                    Console.Write("Enter Age: ");
                    newStudent.Age = int.Parse(Console.ReadLine());

                    Console.Write("Enter Mobile: ");
                    newStudent.Mobile = Console.ReadLine();

                    students.Add(newStudent);
                    service.SaveStudents(students);

                    Console.WriteLine(" Student added successfully!");
                }
                else if (choice == "2")
                {
                    var students = service.LoadStudents();
                    if (students.Count == 0)
                    {
                        Console.WriteLine("No students found.");
                    }
                    else
                    {
                        Console.WriteLine("\n--- Students List ---");
                        foreach (var student in students)
                        {
                            Console.WriteLine(
                                $"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Mobile: {student.Mobile}"
                            );
                        }
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again.");
                }
            }
        }
    }
}
