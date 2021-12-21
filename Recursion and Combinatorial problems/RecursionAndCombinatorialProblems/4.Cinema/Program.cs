using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Cinema
{
    public class Program
    {
        static List<string> nonStaticPeople;
        static string[] people;
        static bool[] takenSeats;

        static void Main(string[] args)
        {
            nonStaticPeople = Console.ReadLine().Split(", ", StringSplitOptions.None).ToList();
            people = new string[nonStaticPeople.Count];
            takenSeats = new bool[nonStaticPeople.Count];

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "generate")
            {
                var parts = inputLine.Split(" - ").ToArray();
                var name = parts[0];
                var position = int.Parse(parts[1]) - 1;

                takenSeats[position] = true;
                nonStaticPeople.Remove(name);
                people[position] = name;
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= nonStaticPeople.Count)
            {
                PrintOutput();
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < nonStaticPeople.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void PrintOutput()
        {
            int nonStaticPeopleIndex = 0;

            for (int i = 0; i < people.Length; i++)
            {
                if (takenSeats[i] == false)
                {
                    people[i] = nonStaticPeople[nonStaticPeopleIndex++];
                }
            }

            Console.WriteLine(string.Join(' ', people));
        }

        private static void Swap(int first, int second)
        {
            var temp = nonStaticPeople[first];
            nonStaticPeople[first] = nonStaticPeople[second];
            nonStaticPeople[second] = temp;
        }
    }
}
