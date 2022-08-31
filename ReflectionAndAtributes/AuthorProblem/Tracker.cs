using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.Public |BindingFlags.Static);

            foreach (MethodInfo method in methodInfos)
            {
                if(method.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var atributes = method.GetCustomAttributes(false);
                    foreach (var atribute in atributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {atribute.GetType().Name}");
                    }
                }
            }
        }
    }
}
