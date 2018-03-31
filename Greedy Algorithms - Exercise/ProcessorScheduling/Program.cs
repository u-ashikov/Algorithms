namespace ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public class Task
        {
            public Task(int value, int deadline, int index)
            {
                this.Value = value;
                this.Deadline = deadline;
                this.Index = index;
            }

            public int Value { get; private set; }

            public int Deadline { get; private set; }

            public int Index { get; private set; }
        }

        public static void Main()
        {
            var tasksCount = int.Parse(Console.ReadLine()
                .Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[1]);

            var tasks = new List<Task>();

            for (int i = 0; i < tasksCount; i++)
            {
                var info = Console.ReadLine()
                    .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var task = new Task(info[0], info[1],i+1);
                tasks.Add(task);
            }

            var maxDeadline = tasks.Max(t => t.Deadline);

            tasks = tasks
                .OrderByDescending(t => t.Value)
                .ThenByDescending(t => t.Deadline)
                .Take(maxDeadline)
                .ToList();

            Console.WriteLine($"Optimal schedule: {string.Join(" -> ",tasks.OrderBy(t=>t.Deadline).ThenByDescending(t=>t.Value).Select(t=>t.Index))}");

            Console.WriteLine($"Total value: {tasks.Sum(t=>t.Value)}");
        }
    }
}
