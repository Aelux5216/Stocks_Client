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
        private int price, quantity;

        //Default constructor
        public Companies()
        {

        }

        //Main constructor
        public Companies(string inputSymbol, string inputCompany, int inputPrice, int inputQuantity)
        {
            symbol = inputSymbol;
            company = inputCompany;
            price = inputPrice;
            quantity = inputQuantity;
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
        public int GetPrice()
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
        public void SetPrice(int inputPrice)
        {
            price = inputPrice;
        }
        public void SetQuantity(int inputQuantity)
        {
            quantity = inputQuantity;
        }
    }
}
