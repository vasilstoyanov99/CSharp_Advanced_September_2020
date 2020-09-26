using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentsData = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] studentInfo = Console.ReadLine().Split();
                string studentName = studentInfo[0];
                double grade = double.Parse(studentInfo[1]);

                if (!studentsData.ContainsKey(studentName))
                {
                    studentsData.Add(studentName, new List<double>());
                    studentsData[studentName].Add(grade);
                }
                else
                {
                    studentsData[studentName].Add(grade);
                }
            }

            foreach (var student in studentsData)
            {
                StringBuilder result = new StringBuilder();
                result.Append($"{student.Key} -> ");

                foreach (var grade in student.Value)
                {
                    result.Append($"{grade:f2} ");
                }

                result.Append($"(avg: {student.Value.Average():f2})");
                Console.WriteLine(result.ToString());
            }
        }
    }
}
