using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataSortSearch
{
    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\Mphasis\SimpleliLearn Doc .net\Practice Problems\DataStructure\Retrieve Sorting and Searching\Student Data.txt";
            List<Student> students = new List<Student>();
            string[] lines = File.ReadAllLines(filePath);

            // Print headers
            string[] headers = lines[0].Split(',');
            // Parse the data and store it in a list of objects
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                Student student = new Student();
                student.Name = parts[0];
                student.Class = parts[1];
                students.Add(student);
            }
            // Sort the list by name
            students = students.OrderBy(s => s.Name).ToList();

            // Display the sorted data on the screen
            foreach (Student student in students)
            {
                Console.WriteLine("{0,-15} {1,-5}", student.Name, student.Class);
            }
            while (true)
            {
                // Search for a student by name
                Console.WriteLine("\nEnter Name of student To Search: \n");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    name = char.ToUpper(name[0]) + name.Substring(1);
                }
                Student result = students.Find(s => s.Name == name);
                if (result != null)
                {
                    Console.WriteLine("\n{0,-15} {1,-5}", result.Name, result.Class);
                }
                else
                {
                    Console.WriteLine("\nStudent not found.");
                }
            }

        }
    }
}
