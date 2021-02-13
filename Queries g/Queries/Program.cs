
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            //LINQ systax
            var query =
                from c in context.Courses
                where c.Name.Contains("C#")
                orderby c.Name
                select c;

            foreach(var course in query)
            {
                System.Console.WriteLine(course.Name);
            }

            //Extension methods
            var courses = context.Courses
                .Where(c => c.Name.Contains("c#"))
                .OrderBy(c => c.Name);


        }
    }
}
