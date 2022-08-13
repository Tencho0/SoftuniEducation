namespace OnlineShop.Models.Products
{
    using OnlineShop.Common.Constants;
    using System;

    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => id;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);

                id = value;
            }
        }

        public string Manufacturer
        {
            get => manufacturer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);

                manufacturer = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidModel);

                model = value;
            }
        }

        public virtual decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);

                price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => overallPerformance;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);

                overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return string.Format(SuccessMessages.ProductToString, this.overallPerformance, this.price, this.GetType().Name, this.manufacturer, this.model, this.id);
        }
    }
}
