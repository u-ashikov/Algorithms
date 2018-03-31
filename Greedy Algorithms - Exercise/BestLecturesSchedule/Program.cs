namespace BestLecturesSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public class Lecture : IComparable<Lecture>
        {
            public Lecture(string name, int startTime, int finishTime)
            {
                this.Name = name;
                this.StartTime = startTime;
                this.FinishTime = finishTime;
            }

            public string Name { get; private set; }

            public int StartTime { get; private set; }

            public int FinishTime { get; private set; }

            public int CompareTo(Lecture other)
            {
               return this.FinishTime.CompareTo(other.FinishTime);
            }
        }

        public static void Main()
        {
            var lectures = new SortedSet<Lecture>();

            var count = int.Parse(Console.ReadLine().Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[1]);

            for (int i = 0; i < count; i++)
            {
                var info = Console.ReadLine()
                    .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);

                var name = info[0];
                var start = int.Parse(info[1]);
                var end = int.Parse(info[2]);

                var lecture = new Lecture(name, start, end);
                lectures.Add(lecture);
            }

            var result = new List<Lecture>();
            result.Add(lectures.First());
            lectures.Remove(result.First());

            foreach (var l in lectures)
            {
                if (l.StartTime >= result.Last().FinishTime)
                {
                    result.Add(l);
                }
            }

            Console.WriteLine($"Lectures ({result.Count}):");

            Console.WriteLine(string.Join(Environment.NewLine, result.Select(l=>$"{l.StartTime}-{l.FinishTime} -> {l.Name}")));
        }
    }
}
