using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where t.GetCustomAttributes<SampleAttribute>().Count() > 0
                        select t;
            foreach (var type in types)
            {
                Console.WriteLine(type.Name);
                foreach (var p in type.GetProperties())
                {
                    Console.WriteLine(p.Name);

                }
            }
        }
    }

    //AttributeUsage define the rule of my attribute usage in other words difine where can we use this attribute
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SampleAttribute : Attribute
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }

    [Sample(Name = "Test", Version = "1.0")]
    public class Test
    {

        public string xxx { get; set; }
    }

    public class Test2
    {

        public string xxx { get; set; }
    }

}
