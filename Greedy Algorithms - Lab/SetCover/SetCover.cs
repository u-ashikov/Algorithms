using System;
using System.Collections.Generic;
using System.Linq;

public class SetCover
{
    public static void Main(string[] args)
    {
        var universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
        var sets = new[]
        {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

        var selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");
        foreach (var set in selectedSets)
        {
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
        }
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        var result = new List<int[]>();
        var allSets = new HashSet<int[]>(sets);

        while (universe.Count != 0)
        {
            allSets = new HashSet<int[]>(allSets.OrderByDescending(s => s.Intersect(universe).Count()).ThenBy(s => s.Length));
            var currentSet = allSets.FirstOrDefault();

            var setContainsElements = universe.Intersect(currentSet);

            if (setContainsElements.Any())
            {
                result.Add(currentSet);

                foreach (var element in currentSet)
                {
                    universe.Remove(element);
                }
            }

            allSets.Remove(currentSet);
        }

        return result;
    }
}
