using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    class Classroom
    {
        private Dictionary<string, Student> allStudents;
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return allStudents.Count;
            }
        }

        public Classroom(int capacity)
        {
            Capacity = capacity;
            allStudents = new Dictionary<string, Student>();
        }

        public string RegisterStudent(Student student)
        {
            if (allStudents.Count < Capacity)
            {
                if (!allStudents.ContainsKey(student.FirstName))
                {
                    allStudents.Add(student.FirstName, student);
                    return $"Added student {student.FirstName} {student.LastName}";
                }
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (allStudents.ContainsKey(firstName))
            {
                if (allStudents[firstName].LastName == lastName)
                {
                    allStudents.Remove(firstName);
                    return $"Dismissed student {firstName} {lastName}";
                }
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            var sorted = allStudents.Values.Where(x => x.Subject == subject).ToList();

            if (sorted.Count > 0)
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine($"Subject: {subject}");
                result.AppendLine("Students:");

                foreach (var student in sorted)
                {
                    result.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return result.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return allStudents.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            if (allStudents.ContainsKey(firstName))
            {
                if (allStudents[firstName].LastName == lastName)
                {
                    return allStudents[firstName];
                }
            }

            return null;
        }
    }
}
