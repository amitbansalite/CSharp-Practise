using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.Entities;

namespace ConsoleApplication1.LINQ
{
    public class SelectMany
    {
        public void selectMany_simpleUsages_1()
        {
            // select all words starting with the letter m (ignore case)
            string[] strings = 
                            {
                                "A penny saved is a penny earned.",
                                "The early bird catches the worm.",
                                "The pen is mightier than the sword." 
                            };

            // method 1
            var words = strings.SelectMany(t => t.Split(' '));              // flattening list of list of words into 1 list
            var result = (from word in words
                          where word.ToLower().StartsWith("m")
                          select word).ToList();


            // method 3
            var result2 = (from word in strings
                               .SelectMany(t => t.Split(' ').Select( x => x.ToLower()))
                           where word[0] == 'm'
                           select word
                          ).ToList();

            // method 2
            var result3 = (from sentence in strings
                           let words1 = sentence.Split(' ')         // using the LET keyword in LINQ so that we again get an Ienumerable which can be queried again
                           from word in words1
                           let w = word.ToLower()
                           where w[0] == 'm'
                           select w
                    ).ToList();
        }

        public void complex_example_2()
        {
            // leagues has a list of teams, which has a list of players
            var leagues = new List<League>();

            var allteams = leagues.SelectMany(l => l.teams);

            var allPlayers = leagues.SelectMany(l => l.teams)
                                    .SelectMany(t => t.players);

            var onlyYoungPlayers = leagues.SelectMany(l => l.teams)
                                          .SelectMany(t => t.players)
                                          .Where(p => p.age < 20);

            // players from teams who won matches and from certain states
            var players = leagues.SelectMany(l => l.teams)
                                 .Where(t => t.matchWin > 2)
                                 .SelectMany(t => t.players)
                                 .Where(p => p.homeState == "CA");


            // instead of getting a flatten list
            // select players but also maintain relationship to parent objects
            var players2 = from helper in leagues

                           .SelectMany(l => l.teams, 
                                           (league, team) => new {league, team})

                           where helper.team.matchWin > 2 && helper.league.name.StartsWith("c")
                           select helper;
        }
    }
}
