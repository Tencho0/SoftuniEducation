using System;
using System.Text;

namespace T01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMess = Console.ReadLine();
            string cmd = Console.ReadLine();

            StringBuilder result = new StringBuilder(encryptedMess);

            while (cmd != "Decode")
            {
                string[] givenCmd = cmd.Split('|');
                string currCommand = givenCmd[0];
                if (currCommand == "Move")
                {
                    int count = int.Parse(givenCmd[1]);
                    string sub = result.ToString().Substring(0, count);
                    result.Remove(0, count).Append(sub);
                }
                else if (currCommand == "Insert")
                {
                    int index = int.Parse(givenCmd[1]);
                    string newValue = givenCmd[2];
                    result.Insert(index, newValue);
                }
                else if (currCommand == "ChangeAll")
                {
                    char oldValue = char.Parse(givenCmd[1]);
                    char newValue = char.Parse(givenCmd[2]);
                    result.Replace(oldValue, newValue);
                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {result.ToString()}");


            //string encryptedMess = Console.ReadLine();
            //string cmd = Console.ReadLine();

            //while (cmd != "Decode")
            //{
            //    string[] givenCmd = cmd.Split('|', StringSplitOptions.RemoveEmptyEntries);
            //    string currCommand = givenCmd[0];
            //    if (currCommand == "Move")
            //    {
            //        int count = int.Parse(givenCmd[1]);
            //        StringBuilder sb = new StringBuilder();
            //        string sub = encryptedMess.Substring(0, count);
            //        sb.Append(encryptedMess.Remove(0, count));
            //        sb.Append(sub);
            //        encryptedMess = sb.ToString();
            //    }
            //    else if (currCommand == "Insert")
            //    {
            //        int index = int.Parse(givenCmd[1]);
            //        string newValue = givenCmd[2];
            //        encryptedMess = encryptedMess.Insert(index, newValue);
            //    }
            //    else if (currCommand == "ChangeAll")
            //    {
            //        char oldValue = char.Parse(givenCmd[1]);
            //        char newValue = char.Parse(givenCmd[2]);
            //        encryptedMess = encryptedMess.Replace(oldValue, newValue);
            //    }
            //    cmd = Console.ReadLine();
            //}
            //Console.WriteLine($"The decrypted message is: {encryptedMess}");
        }
    }
}
