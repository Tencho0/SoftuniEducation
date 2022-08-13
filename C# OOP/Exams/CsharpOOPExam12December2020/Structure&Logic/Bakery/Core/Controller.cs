namespace Bakery.Core
{
    using Bakery.Core.Contracts;
    using Bakery.Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables;
    using Bakery.Models.Tables.Contracts;
    using Bakery.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == nameof(Tea))
                drink = new Tea(name, portion, brand);
            else if (type == nameof(Water))
                drink = new Water(name, portion, brand);

            this.drinks.Add(drink);
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == nameof(Bread))
                food = new Bread(name, price);
            else if (type == nameof(Cake))
                food = new Cake(name, price);

            this.bakedFoods.Add(food);
            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == nameof(InsideTable))
                table = new InsideTable(tableNumber, capacity);
            else if (type == nameof(OutsideTable))
                table = new OutsideTable(tableNumber, capacity);

            this.tables.Add(table);
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in this.tables.Where(x => !x.IsReserved))
                sb.AppendLine(table.GetFreeTableInfo());

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var bill = table.GetBill();
            totalIncome += bill;
            table.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");
            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (table == null)
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);

            if (drink == null)
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);

            table.OrderDrink(drink);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, $"{drinkName} {drinkBrand}");
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var food = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (table == null)
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);

            if (food == null)
                return string.Format(OutputMessages.NonExistentFood, foodName);

            table.OrderFood(food);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            var availableTable = this.tables.FirstOrDefault(x => !x.IsReserved && x.Capacity >= numberOfPeople);

            if (availableTable == null)
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);

            availableTable.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, availableTable.TableNumber, numberOfPeople);
        }
    }
}
