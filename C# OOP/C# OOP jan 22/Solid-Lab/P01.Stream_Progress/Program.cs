using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        public static void Main()
        {
            var progress = new StreamProgressInfo(new File("file",3, 5));
            var progress2 = new StreamProgressInfo(new Music("music", "album", 2, 3));
        }
    }
}
