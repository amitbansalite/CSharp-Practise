using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.Entities.msdn;

namespace ConsoleApplication1.LINQ
{
    // when using Group in LINQ remember that 2 foreach loop are required
        // selected group.key is the parameter
        // 2nd loop will enumerate over all vaues in that group

    public class Group
    {
        public enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };

        //Helper method, used in GroupByRange. 
        public static int GetPercentile(Student s)
        {
            double avg = s.ExamScores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }

        #region
        public static List<Student> students = new List<Student>
    {
        new Student {FirstName = "Terry", LastName = "Adams", ID = 120, 
            Year = GradeLevel.SecondYear, 
            ExamScores = new List<int>{ 99, 82, 81, 79}},
        new Student {FirstName = "Fadi", LastName = "Fakhouri", ID = 116, 
            Year = GradeLevel.ThirdYear,
            ExamScores = new List<int>{ 99, 86, 90, 94}},
        new Student {FirstName = "Hanying", LastName = "Feng", ID = 117, 
            Year = GradeLevel.FirstYear, 
            ExamScores = new List<int>{ 93, 92, 80, 87}},
        new Student {FirstName = "Cesar", LastName = "Garcia", ID = 114, 
            Year = GradeLevel.FourthYear,
            ExamScores = new List<int>{ 97, 89, 85, 82}},
        new Student {FirstName = "Debra", LastName = "Garcia", ID = 115, 
            Year = GradeLevel.ThirdYear, 
            ExamScores = new List<int>{ 35, 72, 91, 70}},
        new Student {FirstName = "Hugo", LastName = "Garcia", ID = 118, 
            Year = GradeLevel.SecondYear, 
            ExamScores = new List<int>{ 92, 90, 83, 78}},
        new Student {FirstName = "Sven", LastName = "Mortensen", ID = 113, 
            Year = GradeLevel.FirstYear, 
            ExamScores = new List<int>{ 88, 94, 65, 91}},
        new Student {FirstName = "Claire", LastName = "O'Donnell", ID = 112, 
            Year = GradeLevel.FourthYear, 
            ExamScores = new List<int>{ 75, 84, 91, 39}},
        new Student {FirstName = "Svetlana", LastName = "Omelchenko", ID = 111, 
            Year = GradeLevel.SecondYear, 
            ExamScores = new List<int>{ 97, 92, 81, 60}},
        new Student {FirstName = "Lance", LastName = "Tucker", ID = 119, 
            Year = GradeLevel.ThirdYear, 
            ExamScores = new List<int>{ 68, 79, 88, 92}},
        new Student {FirstName = "Michael", LastName = "Tucker", ID = 122, 
            Year = GradeLevel.FirstYear, 
            ExamScores = new List<int>{ 94, 92, 91, 91}},
        new Student {FirstName = "Eugene", LastName = "Zabokritski", ID = 121,
            Year = GradeLevel.FourthYear, 
            ExamScores = new List<int>{ 96, 85, 91, 60}}
    };
        #endregion


        public void GroupByBoolean()
        {
            Console.WriteLine("\r\nGroup by a Boolean into two groups with string keys");
            Console.WriteLine("\"True\" and \"False\" and project into a new anonymous type:");

            var queryGroupByAverages = from student in students
                                       group new { student.FirstName, student.LastName }
                                            by student.ExamScores.Average() > 75 into studentGroup
                                       select studentGroup;

            foreach (var studentGroup in queryGroupByAverages)
            {
                Console.WriteLine("Key: {0}", studentGroup.Key);
                foreach (var student in studentGroup)
                    Console.WriteLine("\t{0} {1}", student.FirstName, student.LastName);
            }
        }

        public void GroupByRange()
        {
            Console.WriteLine("\r\nGroup by numeric range and project into a new anonymous type:");

            var queryNumericRange =
                from student in students
                let percentile = GetPercentile(student)
                group new { student.FirstName, student.LastName } by percentile into percentGroup
                orderby percentGroup.Key
                select percentGroup;

            // Nested foreach required to iterate over groups and group items. 
            foreach (var studentGroup in queryNumericRange)
            {
                Console.WriteLine("Key: {0}", (studentGroup.Key * 10));
                foreach (var item in studentGroup)
                {
                    Console.WriteLine("\t{0}, {1}", item.LastName, item.FirstName);
                }
            }
        }

        public void GroupBySubstring()
        {
            Console.WriteLine("\r\nGroup by something other than a property of the object:");

            // if not using INTO keyword then select not required again

            var queryFirstLetters =
                from student in students
                group student by student.LastName[0];

            foreach (var studentGroup in queryFirstLetters)
            {
                Console.WriteLine("Key: {0}", studentGroup.Key);
                // Nested foreach is required to access group items. 
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("\t{0}, {1}", student.LastName, student.FirstName);
                }
            }
        }

        // very good example which creates groups based on 1) student last anme first letter b) boolean value
        public void GroupByCompositeKey()
        {

            var queryHighScoreGroups =
                from student in students
                group student by new
                    {
                        FirstLetter = student.LastName[0],
                        Score = student.ExamScores[0] > 85
                    }
                into studentGroup
                orderby studentGroup.Key.FirstLetter
                select studentGroup;

            Console.WriteLine("\r\nGroup and order by a compound key:");
            foreach (var scoreGroup in queryHighScoreGroups)
            {
                string s = scoreGroup.Key.Score == true ? "more than" : "less than";
                Console.WriteLine("Name starts with {0} who scored {1} 85", scoreGroup.Key.FirstLetter, s);
                foreach (var item in scoreGroup)
                {
                    Console.WriteLine("\t{0} {1}", item.FirstName, item.LastName);
                }
            }
        }

        public void subQuery_Group()
        {
            var queryGroupMax =
                               from student in students
                               group student by student.Year into studentGroup
                               select new
                               {
                                   Level = studentGroup.Key,
                                   HighestScore =
                                           (from student2 in studentGroup
                                            select student2.ExamScores.Average()
                                            ).Max()
                               };

            int count = queryGroupMax.Count();
            Console.WriteLine("Number of groups = {0}", count);

            foreach (var item in queryGroupMax)
            {
                Console.WriteLine("  {0} Highest Score={1}", item.Level, item.HighestScore);
            }
        }

        // interesting one
        public void QueryNestedGroups()
        {
            // create a group of students by year
            // for each year, create groups for students by last name

            var queryNestedGroups = from student in students
                                    group student by student.Year into newGroup1
                                    from newGroup2 in
                                        (from student in newGroup1
                                         group student by student.LastName)
                                    group newGroup2 by newGroup1.Key;

                        
               
            // Three nested foreach loops are required to iterate  
            // over all elements of a grouped group. Hover the mouse  
            // cursor over the iteration variables to see their actual type. 
            foreach (var outerGroup in queryNestedGroups)
            {
                Console.WriteLine("DataClass.Student Level = {0}", outerGroup.Key);
                foreach (var innerGroup in outerGroup)
                {
                    Console.WriteLine("\tNames that begin with: {0}", innerGroup.Key);
                    foreach (var innerGroupElement in innerGroup)
                    {
                        Console.WriteLine("\t\t{0} {1}", innerGroupElement.LastName, innerGroupElement.FirstName);
                    }
                }
            }


        }

        public void group_result_apply_Average_example()
        {
            /*var categories = from p in products
                             group p by p.Category into g
                             select new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) };*/

        }


    }
}
