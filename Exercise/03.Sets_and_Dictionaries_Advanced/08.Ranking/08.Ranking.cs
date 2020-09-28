using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var passwordsForContests = new Dictionary<string, string>();
            var candidatesResults = new Dictionary<string, Candidate>();
            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] data = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contest = data[0];
                string password = data[1];
                passwordsForContests.Add(contest, password);
                input = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "end of submissions")
            {
                string[] data = secondInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                AddCandidateData(passwordsForContests, candidatesResults, data);
                secondInput = Console.ReadLine();
            }

            foreach (var item in candidatesResults.Values)
            {
                item.SumTotalPoints();
            }

            foreach (var bestOne in candidatesResults.OrderByDescending(x => x.Value.TotalPoints))
            {
                Console.WriteLine($"Best candidate is {bestOne.Key} with total {bestOne.Value.TotalPoints} points.");
                break;
            }

            candidatesResults = candidatesResults.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine("Ranking:");

            foreach (var candidate in candidatesResults)
            {
                Console.WriteLine(candidate.Key);

                foreach (var results in candidate.Value.Results.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {results.Key} -> {results.Value}");
                }
            }
        }

        static void AddCandidateData(Dictionary<string, string> passwordsForContests, 
            Dictionary<string, Candidate> candidatesResults, string[] data)
        {
            string contest = data[0];
            string password = data[1];
            string username = data[2];
            int points = int.Parse(data[3]);

            if (passwordsForContests.ContainsKey(contest) && passwordsForContests[contest] == password)
            {
                if (!candidatesResults.ContainsKey(username))
                {
                    candidatesResults.Add(username, new Candidate());
                    candidatesResults[username].Results.Add(contest, points);
                }
                else
                {
                    if (!candidatesResults[username].Results.ContainsKey(contest))
                    {
                        candidatesResults[username].Results.Add(contest, points);
                    }
                    else if (points > candidatesResults[username].Results[contest])
                    {
                        candidatesResults[username].Results[contest] = points;
                    }
                }
            }
        }

        class Candidate
        {
            public Dictionary<string, int> Results { get; set; }
            public int TotalPoints { get; set; }
            public Candidate()
            {
                this.Results = new Dictionary<string, int>();
            }

            public void SumTotalPoints()
            {
                foreach (var points in this.Results.Values)
                {
                    this.TotalPoints += points;
                }
            }
        }
    }
}
