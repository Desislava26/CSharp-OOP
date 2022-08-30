using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStream stream = new Music("Lana Del Rey", "Born To Die", 60, 128);
            StreamProgressInfo info = new StreamProgressInfo(stream);

        }
    }
}
