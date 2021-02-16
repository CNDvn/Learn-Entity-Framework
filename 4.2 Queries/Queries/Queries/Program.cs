
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinqSyntax();
        }
        static void LinqExtensionMethod()
        {
            var context = new PlutoContext();

            //Partitioning
            var courses = context.Courses.Skip(10).Take(10);
            //Element Operators
            context.Courses.OrderBy(c => c.Level).FirstOrDefault();
            //Luoi qua khong viet nua
        }
        static void LinqSyntax() 
        {
            var context = new PlutoContext();

            var query = from c in context.Courses
                        where c.Author.Id == 1
                        orderby c.Level descending, c.Name
                        select new { Name = c.Name, Author = c.Author.Name };

            //GROUP
            var queryGroup = from c in context.Courses
                             group c by c.Level
                             into g
                             select g;
            foreach (var group in queryGroup)
            {
                System.Console.WriteLine("{0} ({1})", group.Key, group.Count());
                foreach (var course in group)
                    System.Console.WriteLine("\t\t" + course.Name + " - level: " + course.Level);
            }

            //JOIN
            var queryJoin = from c in context.Courses
                            join a in context.Authors on c.AuthorId equals a.Id
                            select new { CourseName = c.Name, AuthorName = a.Name };
            foreach (var c in queryJoin)
                System.Console.WriteLine("name: {0} - author: {1}", c.CourseName, c.AuthorName);

            //GROUP JOIN 
            var queryGrJoin = from a in context.Authors
                              join c in context.Courses on a.Id equals c.AuthorId into g
                              select new { AuthorName = a.Name, Course = g.Count() };
            foreach (var x in queryGrJoin)
                System.Console.WriteLine("{0} ({1})", x.AuthorName, x.Course);

            //CROSS JOIN
            var queryCrossJoin = from a in context.Authors
                                 from c in context.Courses
                                 select new { AuthorName = a.Name, CourseName = c.Name };

        }
    }
}
