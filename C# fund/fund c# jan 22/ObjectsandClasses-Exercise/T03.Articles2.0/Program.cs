using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(", ");
                var article = new Article(command[0], command[1], command[2]);
                articles.Add(article);
            }
            string criteriaToOrder = Console.ReadLine();
            switch (criteriaToOrder)
            {
                case "title":
                    articles.Sort((aritcle1, article2) => aritcle1.Title.CompareTo(article2.Title));
                    break;
                case "content":
                    articles.Sort((aritcle1, article2) => aritcle1.Content.CompareTo(article2.Content));
                    break;
                case "author":
                    articles.Sort((aritcle1, article2) => aritcle1.Author.CompareTo(article2.Author));
                    break;
            }
            foreach (var item in articles)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Article
    {
        private string title_;
        private string content_;
        private string author_;

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
        public string Title { get => title_; set => title_ = value; }
        public string Content { get => content_; set => content_ = value; }
        public string Author { get => author_; set => author_ = value; }
    }
}
