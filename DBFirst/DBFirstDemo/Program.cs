using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DBFirstDemoEntities();
            var list = (from item in context.Posts select item);
            foreach(var item in list)
            {
                Console.WriteLine(item.PostID + " : " + item.Title);
            }
            //Console.WriteLine(context.Posts.Find(1).Title);

        }
    }
}
