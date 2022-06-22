using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    //Klassen är sealed för att den inte ska kunna ärvas.
    public sealed class CurrencyExchange
    {
        
        public string CurrencyToExchangeFrom = "";
        public string CurrencyToExchangeTo = "";
        public int CurrencyAmount = 0;
        public decimal CurrencyExchangeRate = 0;

        //En privata statisk variabel 
        private static CurrencyExchange instance = null;

        //En publik statisk property/metod som retunerar instansen av Singleton klassen.
        public static CurrencyExchange GetInstance
        {
            get
            {
                //En if-sats som kollar om det redan har skapats en instans av klassen, antingen skapar den en ny instans eller retunerar den som redan finns.
                if (instance == null)
                {
                    instance = new CurrencyExchange();
                }
                return instance;
            }
        }

        //Två publika metoder för att kunna hämta info om vald valuta
        public string GetCurrencyToExchangeFrom()
        {
            return CurrencyToExchangeFrom;
        }
        public string GetCurrencyToExchangeTo()
        {
            return CurrencyToExchangeTo;
        }

        //Privat konstruktor och utan parametrar för att säkerställa att klassen endast kan instasieras inom klassen. 
        private CurrencyExchange()
        {
            Console.WriteLine("Ange vilken valuta du vill växla från: Euro, SEK eller USD");
            CurrencyToExchangeFrom = Console.ReadLine().ToUpper();
            Console.WriteLine("Ange vilken valuta du vill växla till: Euro, SEK eller USD");
            CurrencyToExchangeTo = Console.ReadLine().ToUpper();
            Console.WriteLine("Ange beloppet du vill växla: ");
            CurrencyAmount = int.Parse(Console.ReadLine());
            GetExchangeRate();
        }
        public void PrintDetails()
        {
            Console.Clear();
            Console.WriteLine($"Du har valt att växla {CurrencyAmount} {CurrencyToExchangeFrom} till {Math.Round((CurrencyAmount * CurrencyExchangeRate), 2)} {CurrencyToExchangeTo}");
            
        }
        private void GetExchangeRate()
        {
            switch (CurrencyToExchangeFrom)
            {
                case "SEK":
                    switch (CurrencyToExchangeTo)
                    {
                        case "EURO":
                            CurrencyExchangeRate = (decimal)(1 / 9.48);
                            break;
                        case "USD":
                            CurrencyExchangeRate = (decimal)(1 / 8.08); 
                            break;
                        case "SEK":
                            CurrencyExchangeRate = 1 * 1;
                            break;
                    }
                    break;
                case "EURO":
                    switch (CurrencyToExchangeTo)
                    {
                        case "SEK":
                            CurrencyExchangeRate = (decimal)(1 * 9.48);
                            break;
                        case "USD":
                            CurrencyExchangeRate = (decimal)(1 / 0.85);
                            break;
                        case "EURO":
                            CurrencyExchangeRate = 1 * 1;
                            break;
                    }
                    break;
                case "USD":
                    switch (CurrencyToExchangeTo)
                    {
                        case "SEK":
                            CurrencyExchangeRate = (decimal)(1 * 8.08);
                            break;
                        case "EURO":
                            CurrencyExchangeRate = (decimal)(1 * 0.85);
                            break;
                        case "USD":
                            CurrencyExchangeRate = 1 * 1;
                            break;
                    }
                    break;
            }
        }
        
    }
}
