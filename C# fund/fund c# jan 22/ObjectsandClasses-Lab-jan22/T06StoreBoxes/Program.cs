using System;
using System.Collections.Generic;
using System.Linq;

namespace T06StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Box> boxes = new List<Box>();
            while (command != "end")
            {
                string[] givenCmd = command.Split();

                long serialNum = long.Parse(givenCmd[0]);
                string itemName = givenCmd[1];
                int itemQuantity = int.Parse(givenCmd[2]);
                decimal itemPrice = decimal.Parse(givenCmd[3]);
                decimal priceForBox = itemQuantity * itemPrice;

                Box currBox = new Box();

                currBox.SerialNumber = serialNum;
                currBox.Item.Name = itemName;
                currBox.Item.Price = itemPrice;
                currBox.ItemQuantity = itemQuantity;
                currBox.PriceForaBox = priceForBox;

                boxes.Add(currBox);

                command = Console.ReadLine();
            }

            List<Box> sortedBoxes = boxes.OrderByDescending(boxes => boxes.PriceForaBox).ToList();

            foreach (Box currBox in sortedBoxes)
            {
                Console.WriteLine(currBox.SerialNumber);
                Console.WriteLine($"-- {currBox.Item.Name} - ${currBox.Item.Price:f2}: {currBox.ItemQuantity}");
                Console.WriteLine($"-- ${currBox.PriceForaBox:F2}");
            }
        }
    }
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public long SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceForaBox { get; set; }
    }
}
