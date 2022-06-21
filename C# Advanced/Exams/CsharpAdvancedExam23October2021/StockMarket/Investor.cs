using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private Dictionary<string, Stock> portfolio;
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new Dictionary<string, Stock>();
        }
        public int Count => portfolio.Count;
        public Dictionary<string, Stock> Portfolio
        {
            get { return portfolio; }
            set { portfolio = value; }
        }
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }
        public decimal MoneyToInvest
        {
            get { return moneyToInvest; }
            set { moneyToInvest = value; }
        }
        public string BrokerName
        {
            get { return brokerName; }
            set { brokerName = value; }
        }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10_000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.MoneyToInvest -= stock.PricePerShare;
                Portfolio[stock.CompanyName] = stock;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.ContainsKey(companyName))
                return $"{companyName} does not exist.";

            if (sellPrice < Portfolio[companyName].PricePerShare)
                return $"Cannot sell {companyName}.";

            Portfolio.Remove(companyName);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            if (Portfolio.ContainsKey(companyName))
                return Portfolio[companyName];
            return null;
        }
        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count == 0)
                return null;

            decimal max = Portfolio.Values.Max(x => x.MarketCapitalization);
            return Portfolio.Values.First( y=> y.MarketCapitalization >= max);
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {fullName} with a broker {brokerName} has stocks:");

            foreach (var item in portfolio)
                sb.AppendLine(item.Value.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
