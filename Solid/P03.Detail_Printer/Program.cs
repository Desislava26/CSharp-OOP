using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using P03.DetailPrinter;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IEmployee person = new Employee("Veni");
            IList<IEmployee> emp = new List<IEmployee>();
            emp.Add(person);
            ICollection<string> documents = new List<string>() {"document1", "document2"};
            IEmployee personTwo = new Manager("Desi",documents);
            emp.Add(personTwo);
            DetailsPrinter print = new DetailsPrinter(emp);
            print.PrintDetails();   
            
        }
    }
}
