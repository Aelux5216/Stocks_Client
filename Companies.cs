using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks_Client
{
    class Companies
    {
        //Variables 
        private string symbol, company;
        private int quantity;
        private decimal price;

        //Default constructor
        public Companies()
        {

        }

        //Main constructor
        public Companies(string inputSymbol, string inputCompany, decimal inputPrice, int inputQuantity)
        {
            symbol = inputSymbol;
            company = inputCompany;
            price = inputPrice;
            quantity = inputQuantity;
        }

        //Display
        public string[] Display()
        {
            string sSymbol = symbol;
            string sCompany = company;
            string sPrice = price.ToString();
            string sQuantity = quantity.ToString();

            string[] output = new string[] { sSymbol, sCompany, sPrice, sQuantity };

            return output;
        }

        //Getters
        public string GetSymbol()
        {
            return symbol;
        }
        public string GetCompany()
        {
            return company;
        }
        public decimal GetPrice()
        {
            return price;
        }
        public int GetQuantity()
        {
            return quantity;
        }

        //Setters
        public void SetId(string inputSymbol)
        {
            symbol = inputSymbol;
        }
        public void SetCompany(string inputCompany)
        {
            company = inputCompany;
        }
        public void SetPrice(decimal inputPrice)
        {
            price = inputPrice;
        }
        public void SetQuantity(int inputQuantity)
        {
            quantity = inputQuantity;
        }
    }
}
