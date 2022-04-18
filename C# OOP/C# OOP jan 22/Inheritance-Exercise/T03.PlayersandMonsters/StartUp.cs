using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string username = Console.ReadLine();
            int level = int.Parse(Console.ReadLine());
            BladeKnight knight = new BladeKnight(username, level);
            Console.WriteLine(knight);
        }
    }
}