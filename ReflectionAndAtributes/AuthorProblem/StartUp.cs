using AuthorProblem;
using System;


//[Author("George")]
//class Program
//{
//    [Author("George")]
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Hello World!");
//    }
//}

[Author("Victor")]

class StartUp

{

    [Author("George")]

    static void Main(string[] args)

    {

        var tracker = new Tracker();

        tracker.PrintMethodsByAuthor();

    }

}
