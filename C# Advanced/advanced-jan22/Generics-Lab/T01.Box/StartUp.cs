using System;
namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            box.Add("pesho");
            box.Add("sasho");
            box.Add("mitko");
            Console.WriteLine(box.Remove());
            box.Add("ivancho");
            box.Add("dimitrichko");
            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Count);
        }
    }
}
