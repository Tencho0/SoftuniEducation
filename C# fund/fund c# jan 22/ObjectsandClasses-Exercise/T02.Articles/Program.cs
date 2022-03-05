using System;

namespace T02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(", ");
            var article = new Article($"{command[0]}", $"{command[1]}", $"{command[2]}");
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] givenCmd = Console.ReadLine().Split(": ");
                string currCmd = givenCmd[0];
                string newElement = givenCmd[1];
                if (currCmd == "Edit")
                {
                    article.Edit(newElement);
                }
                else if (currCmd == "ChangeAuthor")
                {
                    article.ChangeAuthor(newElement);
                }
                else if (currCmd == "Rename")
                {
                    article.Rename(newElement);
                }
            }
            Console.WriteLine(article);
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
        public void Edit(string content)
        {
            Content = content;
        }
        public void ChangeAuthor(string author)
        {
            Author = author;
        }
        public void Rename(string title)
        {
            Title = title;
        }
      public string Title { get; set; }
      public string Content { get; set; }
      public string Author { get; set; } 
    }
}
