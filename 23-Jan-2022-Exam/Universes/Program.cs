using System;
using System.Collections.Generic;
using System.Linq;

namespace Universes
{
    public class Program
    {
        private static Dictionary<string, List<string>> planets;
        private static List<string> visited;
        private static Dictionary<string, List<string>> universes;
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            planets = new Dictionary<string, List<string>>();
            universes = new Dictionary<string, List<string>>();
            visited = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (line.Length == 0)
                    continue;

                var parent = line[0];

                if (planets.ContainsKey(parent)
                    && line.Length > 1)
                {
                    planets[parent].Add(line[1]);
                }
                else
                {
                    if (line.Length > 1)
                        planets[parent] = new List<string> { line[1] };
                    else
                        planets[parent] = new List<string>();
                }
            }

            foreach (var parentPlanet in planets.Keys)
            {
                if (visited.Contains(parentPlanet) == false)
                {
                    universes[parentPlanet] = new List<string>();
                    DFS(parentPlanet, parentPlanet);
                }
            }

            var universeCount = universes
                .Where(u => u.Value.Count > 1)
                .Select(u => u.Key)
                .ToList()
                .Count;

            Console.WriteLine(universeCount);
        }

        private static void DFS(string node, string parent)
        {
            if (visited.Contains(node))
                return;

            visited.Add(node);
            universes[parent].Add(node);

            if (planets.ContainsKey(node))
            {
                foreach (var child in planets[node])
                {
                    DFS(child, parent);
                }
            }
        }
    }
}
