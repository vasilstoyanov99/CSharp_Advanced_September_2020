using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] threadsArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int taskToKill = int.Parse(Console.ReadLine());
            var threads = new Queue<int>(threadsArray);
            var tasks = new Stack<int>(tasksArray);

            while (true)
            {
                int currTask = tasks.Peek();
                int currThread = threads.Peek();

                if (currTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currThread} killed task {taskToKill}");
                    Console.WriteLine(String.Join(" ", threads));
                    break;
                }

                if (currThread >= currTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }
        }
    }
}
