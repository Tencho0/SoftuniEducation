using System;
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
            Portfolio = new Dictionary<string, Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
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
          //  if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.MarketCapitalization)
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                //this.MoneyToInvest -= stock.MarketCapitalization;
                this.MoneyToInvest -= stock.PricePerShare;
                portfolio[stock.CompanyName] = stock;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!portfolio.ContainsKey(companyName))
                return $"{companyName} does not exist.";
            if (sellPrice < portfolio[companyName].PricePerShare)
                Console.WriteLine($"Cannot sell {companyName}.");

            portfolio.Remove(companyName);
            this.MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            if (portfolio.ContainsKey(companyName))
                return portfolio[companyName];
            return null;
        }
        public Stock FindBiggestCompany()
        {
            if (portfolio.Count == 0)
                return null;
            decimal max = portfolio.Values.Max(x => x.MarketCapitalization);
            return portfolio.Values.First(x => x.MarketCapitalization >= max);
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            
            foreach (var (stockName, stock) in portfolio)
                sb.AppendLine(stock.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
