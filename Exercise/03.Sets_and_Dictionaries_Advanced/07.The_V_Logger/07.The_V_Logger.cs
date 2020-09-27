using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace _07.The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var theVLogger = new Dictionary<string, Vloger>();
            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] data = input.Split();

                switch (data[1])
                {
                    case "joined":
                        AddNewVloger(data[0], theVLogger);
                        break;
                    case "followed":
                        AddNewFollower(data, theVLogger);
                        break;
                }

                input = Console.ReadLine();
            }

            var theMostFamous = new Dictionary<string, int>();
            FindTheMostFamous(theVLogger, theMostFamous);
            string theMostFamousOne = String.Empty;

            if (theMostFamous.Count == 1)
            {
                foreach (var item in theMostFamous)
                {
                    theMostFamousOne = item.Key;
                }
            }
            else
            {
                theMostFamousOne = FindTheBestOf(theMostFamous, theVLogger);
            }

            Console.WriteLine($"The V-Logger has a total of {theVLogger.Count} vloggers in its logs.");
            StringBuilder result = new StringBuilder();
            result.Append($"1. {theMostFamousOne} : {theVLogger[theMostFamousOne].Followers.Count} followers," +
                $" {theVLogger[theMostFamousOne].FollowingCount} following");

            if (theVLogger[theMostFamousOne].Followers.Count > 0)
            {
                Console.WriteLine(result);

                foreach (var follower in theVLogger[theMostFamousOne].Followers)
                {
                    Console.WriteLine($"*  {follower}");
                }
            }

            theVLogger.Remove(theMostFamousOne);
            int numberCounter = 2;

            theVLogger = theVLogger.OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.FollowingCount).ToDictionary(x => x.Key, y => y.Value);

            foreach (var vlogger in theVLogger)
            {
                Console.WriteLine($"{numberCounter}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.FollowingCount} following");
                numberCounter++;
            }
        }

        static string FindTheBestOf(Dictionary<string, int> theMostFamous, Dictionary<string, Vloger> theVLogger)
        {
            int theLessFollowing = int.MaxValue;
            string theChoosenOne = String.Empty;

            foreach (var vlogger in theMostFamous)
            {
                string vloggerName = vlogger.Key;

                if (theVLogger[vloggerName].FollowingCount < theLessFollowing)
                {
                    theLessFollowing = theVLogger[vloggerName].FollowingCount;
                    theChoosenOne = vloggerName;
                }
            }

            return theChoosenOne;
        }
        static void FindTheMostFamous(Dictionary<string, Vloger> theVLogger, Dictionary<string, int> theMostFamous)
        {
            StringBuilder result = new StringBuilder();
            theVLogger = theVLogger.OrderByDescending(x => x.Value.Followers.Count).ToDictionary(x => x.Key, y => y.Value);
            int counter = 1;
            string firstVlogger = String.Empty;

            foreach (var vlogger in theVLogger)
            {
                if (counter == 1)
                {
                    theMostFamous.Add(vlogger.Key, vlogger.Value.Followers.Count);
                    firstVlogger = vlogger.Key;
                }
                else if (counter > 1)
                {
                    int currVlogerFollowes = vlogger.Value.Followers.Count;

                    if (currVlogerFollowes == theMostFamous[firstVlogger])
                    {
                        theMostFamous.Add(vlogger.Key, vlogger.Value.Followers.Count);
                    }
                }
                counter++;
            }
        }

        static void AddNewVloger(string vlogger, Dictionary<string, Vloger> theVLogger)
        {
            if (!theVLogger.ContainsKey(vlogger))
            {
                theVLogger.Add(vlogger, new Vloger(0));
            }
        }

        static void AddNewFollower(string[] vloggers, Dictionary<string, Vloger> theVLogger)
        {
            string vloggerOne = vloggers[0];
            string vloggerTwo = vloggers[2];
            bool areVlogersOnTheList = theVLogger.ContainsKey(vloggerOne) && theVLogger.ContainsKey(vloggerTwo);

            if (areVlogersOnTheList)
            {
                if (vloggerOne != vloggerTwo)
                {
                    if (!theVLogger[vloggerTwo].Followers.Contains(vloggerOne))
                    {
                        theVLogger[vloggerTwo].Followers.Add(vloggerOne);
                        theVLogger[vloggerOne].FollowingCount++;
                    }
                }
            }
        }
    }

    class Vloger
    {
        public SortedSet<string> Followers { get; set; }

        public int FollowingCount { get; set; }

        public Vloger(int following)
        {
            this.FollowingCount = following;
            this.Followers = new SortedSet<string>();
        }
    }
}
