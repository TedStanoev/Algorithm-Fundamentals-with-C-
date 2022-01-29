using System;
using System.Collections.Generic;
using System.Linq;

namespace StoryTelling
{
    public class Program
    {
        private static Dictionary<string, List<string>> stories;
        private static Dictionary<string, int> dependencies;
        private static List<string> storyChain;
        public static void Main(string[] args)
        {
            string inputLine;

            stories = new Dictionary<string, List<string>>();
            storyChain = new List<string>();

            while ((inputLine = Console.ReadLine()) != "End")
            {
                var lineParts = inputLine
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var parent = lineParts[0].Trim();

                if (lineParts.Length > 1)
                {
                    var children = lineParts[1]
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    stories[parent] = children;
                }
                else
                {
                    stories[parent] = new List<string>();
                }
            }

            dependencies = ExtractDependencies();

            while (dependencies.Count > 0)
            {
                var storyToAdd = dependencies.FirstOrDefault(s => s.Value == 0).Key;

                if (storyToAdd == null)
                    break;

                dependencies.Remove(storyToAdd);
                storyChain.Add(storyToAdd);

                foreach (var child in stories[storyToAdd])
                {
                    dependencies[child]--;
                }
            }

            Console.WriteLine(string.Join(" ", storyChain));
        }

        private static Dictionary<string, int> ExtractDependencies()
        {
            var result = new Dictionary<string, int>();

            foreach (var kvp in stories)
            {
                var story = kvp.Key;
                var children = kvp.Value;

                if (result.ContainsKey(story) == false)
                {
                    result[story] = 0;
                }

                foreach (var child in children)
                {
                    if (result.ContainsKey(child) == false)
                    {
                        result[child] = 1;
                    }
                    else
                    {
                        result[child]++;
                    }
                }
            }

            return result;
        }
    }
}
