using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.Entities.msdn;

namespace ConsoleApplication1.LINQ
{
    class DeferredExecution
    {
        #region
        public static List<Student> students = new List<Student>
    {
        new Student {FirstName = "Terry", LastName = "Adams", ID = 120, 
            Year = Group.GradeLevel.SecondYear, 
            ExamScores = new List<int>{ 99, 82, 81, 79}},
        new Student {FirstName = "Fadi", LastName = "Fakhouri", ID = 116, 
            Year = Group.GradeLevel.ThirdYear,
            ExamScores = new List<int>{ 99, 86, 90, 94}},
        new Student {FirstName = "Hanying", LastName = "Feng", ID = 117, 
            Year = Group.GradeLevel.FirstYear, 
            ExamScores = new List<int>{ 93, 92, 80, 87}},
        new Student {FirstName = "Cesar", LastName = "Garcia", ID = 114, 
            Year = Group.GradeLevel.FourthYear,
            ExamScores = new List<int>{ 97, 89, 85, 82}}
    };
        #endregion

        public void test()
        {
            var result = from student in students
                                       where student.ID == 115
                                       select student;

            // the above result is not yet computed, hence the collection can be altered 
            students.Add(new Student
            {
                FirstName = "Debra",
                LastName = "Garcia",
                ID = 115,
                Year = Group.GradeLevel.ThirdYear
            });

            foreach (var stud in result)
            {
                Console.WriteLine(stud.FirstName + ':' + stud.LastName);
            }

            Console.ReadLine();
        }

        public void BetterExplained_DeferredExecution()
        {
            var result = from student in students
                         where student.ID == 115
                         select student;

            foreach (var stud in result)
            {
                Console.WriteLine(stud.FirstName + ':' + stud.LastName);
            }

            students.Add(new Student
            {
                FirstName = "Debra",
                LastName = "Garcia",
                ID = 115,
                Year = Group.GradeLevel.ThirdYear
            });


            //
            //  Enumerating the results again will return the new item, even
            //  though we did not re-assign the Linq expression to it!
            //

            foreach (var stud in result)
            {
                Console.WriteLine(stud.FirstName + ':' + stud.LastName);
            }

            Console.ReadLine();
        }

    }
}
