using System.Text;

namespace StockMarket
{
    public class Stock
    {
        private string companyName;
        private string director;
        private decimal pricePerShare;
        private int totalNumberOfShares;
        private decimal marketCapitalization;

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
            MarketCapitalization = pricePerShare * totalNumberOfShares;
        }

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        public string Director
        {
            get { return director; }
            set { director = value; }
        }
        public decimal PricePerShare
        {
            get { return pricePerShare; }
            set { pricePerShare = value; }
        }
        public int TotalNumberOfShares
        {
            get { return totalNumberOfShares; }
            set { totalNumberOfShares = value; }
        }
        public decimal MarketCapitalization
        {
            get { return pricePerShare * totalNumberOfShares; }
            set { marketCapitalization = value; }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Company: {CompanyName}")
              .AppendLine($"Director: { Director}")
              .AppendLine($"Price per share: ${ PricePerShare}")
              .AppendLine($"Market capitalization: ${ MarketCapitalization}");

            return sb.ToString().TrimEnd();
        }
    }
}
