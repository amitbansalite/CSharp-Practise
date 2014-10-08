using System.Collections.Generic;
using ConsoleApplication1.LINQ;

namespace ConsoleApplication1.Entities.msdn
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public Group.GradeLevel Year;
        public List<int> ExamScores;
    }
}
