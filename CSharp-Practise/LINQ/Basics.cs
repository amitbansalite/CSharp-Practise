using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.Entities;

namespace ConsoleApplication1.LINQ
{
    public class Basics
    {
        public void Test()
        {
            var leagues = new List<League>();
            var teams = new List<Team>();

            // this is very bad way of using LINQ
            var results = leagues.Where(x => x.name == "FC").Single();

            // a lot better is to pass the delegate directly to Single()
            results = leagues.Single(x => x.name == "FC");

            // this can be done woth many other LINQ extension methods
        }

        public void Ordering()
        {
            var leagues = new List<League>();


            var results = from league in leagues
                          orderby league.year
                          select league;
            
            // about Query expression gets Translation by compiler into the following
            leagues.OrderBy(x => x.year)
                   .Select(x => x);


            var results2 = from league in leagues
                           orderby league.year, league.name descending , league.teams.Count() ascending 
                           select league;

            // about Query expression gets Translation by compiler into the following
            leagues.OrderBy(x => x.year)
                    .ThenByDescending(x => x.name)
                    .ThenBy(x => x.teams.Count())
                    .Select(x => x);

        }


       public void concat_example()
        {
            var leagues = new List<League>();
            var teams = new List<Team>();
           
            var result = (from league in leagues
                          where league.teams.Count() > 5
                          select league.name)
                        .Concat(
                            from team in teams
                            where team.matchWin > 5
                            select team.name);

            var result2 = leagues.Where(l => l.teams.Count() > 5).Select(l => l.name)
                          .Concat(teams.Where(t => t.matchWin > 5).Select(t => t.name));
        }

        public void string_example()
        {
            string[] wordsToMatch = { "Historically", "data", "integrated" };

            string[] text = 
                            {
                                "A penny saved is a penny earned.",
                                "The early bird catches the worm.",
                                "The pen is mightier than the sword." 
                            };


            // select all sentences in which all words from given set occurs
            var sentences = from sentence in text
                            let word = sentence.Split(' ')
                            where word.Distinct().Intersect(wordsToMatch).Count() == wordsToMatch.Count()
                            select sentence;
        }

        public void regex_linq()
        {
            // http://msdn.microsoft.com/en-us/library/bb882639.aspx
        }

        public void join_string_list_filter()
        {
            string[] names = 
                            {
                                "Omelchenko,Svetlana,111",
                                "O'Donnell,Claire,112",
                                "Mortensen,Sven,113",
                                "Garcia,Cesar,114",
                                "Garcia,Debra,115",
                                "Tucker,Michael,122"
                            };

            string[] scores = 
                            {
                                "111, 97, 92, 81, 60",
                                "112, 75, 84, 91, 39",
                                "118, 88, 94, 65, 91",
                                "114, 97, 89, 85, 82",
                                "115, 35, 72, 91, 70"
                            };

            var result =  from sentence in names
                          let word = sentence.Split(',')
                          from score in scores
                          let val = score.Split(',')
                          where word[2] == val[0]
                          select new {sentence, score};
        }

        public void group_basics()
        {
            // group sentences which have the same count of words
            string[] text = 
                            {
                                "A penny",
                                "is a penny earned.",
                                "The early",
                                "catches the worm and",
                                "The pen is",
                                "mightier than the sword.",
                                "and also strong"
                            };

            var result = text.GroupBy(sentence => sentence.Split(' ').Count());

            var result2 = from sentence in text
                          group sentence by sentence.Split(' ').Count();

            foreach (var word in result2)
            {
                Console.WriteLine(word.Key);
                foreach (var w in word)
                {
                    Console.WriteLine(w);
                }
            }

            Console.WriteLine("/n/n/n");

            // now select sentences in groups of word count less than 4

            var result3 = from sentence in text
                          group sentence by sentence.Split(' ').Count() into newGroup
                          where newGroup.Key < 4
                          orderby newGroup.Key
                          select newGroup;

            foreach (var words in result3)
            {
                Console.WriteLine(words.Key);
                foreach (var word in words)
                {
                    Console.WriteLine(word);
                }
            }

        }

        public void SequenceEqual_example()
        {
            List<String> pets1 = new List<String> { "pet1", "pet2" };
            List<String> pets2 = new List<String> { "pet1", "pet2" };

            // Determine if the lists are equal. 
            var result = pets1.AsQueryable().SequenceEqual(pets2);

            var result2 = pets1.SequenceEqual(pets2);
        }

        public void Aggregate_example()
        {
            // Determine whether any string in the array is longer than "banana".
            string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };
            
            var longestName = fruits.AsQueryable().Aggregate(
                                            "banana",
                                            (longest, next) => next.Length > longest.Length ? next : longest);
        }

        public void Aggreagte_example_2()
        {
            int[] ints = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };

            // Count the even numbers in the array, using a seed value of 0. 
            int numEven = ints.AsQueryable().Aggregate(
                                0,
                                (total, next) => next % 2 == 0 ? total + 1 : total
                                );
        }

        public void aggreagte_example_3()
        {
            double startBalance = 100.0;

            int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 };

            //This sample uses Aggregate to create a running account balance that subtracts each withdrawal 
                //from the initial balance of 100, 
                //as long as the balance never drops below 0.


            double endBalance =
                attemptedWithdrawals.Aggregate(startBalance,
                    (balance, nextWithdrawal) =>
                        ((nextWithdrawal <= balance) ? (balance - nextWithdrawal) : balance));

            Console.WriteLine("Ending balance: {0}", endBalance);
        }

        public void Take_Skip_Paging()
        {
            // using take and skip methods to implement paging
            // remember that reversing the order or methods will result in 0 elements being returned after page 0

            string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };

            int pagenumber = 3, itemsPerPage = 10;

            var results = fruits.Skip(pagenumber*itemsPerPage)
                                .Take(itemsPerPage);

        }
    }
}
