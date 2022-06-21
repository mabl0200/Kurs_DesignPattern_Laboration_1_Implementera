using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public sealed class CurrencyExchange
    {
        private static string CurrencyToExchangeFrom = "";
        private static string CurrencyToExchangeTo = "";
        private static int CurrencyAmount = 0;
        private static double CurrencyExchangeRate = 0;

        private static CurrencyExchange instance = null;
        public static CurrencyExchange GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrencyExchange();
                }
                return instance;
            }
        }
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
            Console.WriteLine($"Du har valt att växla {CurrencyAmount} {CurrencyToExchangeFrom} till {CurrencyToExchangeTo}");
            Console.WriteLine($"Du kommer att få {(CurrencyAmount * CurrencyExchangeRate)} {CurrencyToExchangeTo}");
        }
        private void GetExchangeRate()
        {
            switch (CurrencyToExchangeFrom)
            {
                case "SEK":
                    switch (CurrencyToExchangeTo)
                    {
                        case "EURO":
                            CurrencyExchangeRate = 1 / 9.48;
                            break;
                        case "USD":
                            CurrencyExchangeRate = 1 / 8.08; 
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
                            CurrencyExchangeRate = 1 * 9.48;
                            break;
                        case "USD":
                            CurrencyExchangeRate = 1 / 0.85;
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
                            CurrencyExchangeRate = 1 * 8.08;
                            break;
                        case "EURO":
                            CurrencyExchangeRate = 1 * 0.85;
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
