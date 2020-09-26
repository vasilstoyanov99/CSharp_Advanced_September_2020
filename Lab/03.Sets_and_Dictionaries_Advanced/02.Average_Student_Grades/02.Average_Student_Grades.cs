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
            Dictionary<string, List<decimal>> studentsData = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] studentInfo = Console.ReadLine().Split();
                string studentName = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);

                if (!studentsData.ContainsKey(studentName))
                {
                    studentsData.Add(studentName, new List<decimal>());
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
