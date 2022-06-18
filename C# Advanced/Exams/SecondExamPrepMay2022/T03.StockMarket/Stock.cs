using System.Text;

namespace StockMarket
{
    public class Stock
    {
        private string companyName;
        private string director;
        private decimal pricePerShare;
        private int totalNumberOfShares;

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
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
        public decimal MarketCapitalization => TotalNumberOfShares * PricePerShare;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Company: {CompanyName}");
            sb.AppendLine($"Director: { Director}");
            sb.AppendLine($"Price per share: ${ PricePerShare}");
            sb.AppendLine($"Market capitalization: ${ MarketCapitalization}");

            return sb.ToString().TrimEnd();
        }
    }
}
