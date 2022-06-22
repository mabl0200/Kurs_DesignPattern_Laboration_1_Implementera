using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    //Klassen är sealed för att den inte ska kunna ärvas.
    public sealed class CurrencyExchange
    {
        //Fyra properties som håller infon från klient när den privata konstruktorn körs.
        public string CurrencyToExchangeFrom { get; } 
        public string CurrencyToExchangeTo { get; }
        public int CurrencyAmount { get; }
        public decimal CurrencyExchangeRate { get; }

        //En privat statisk variabel 
        private static CurrencyExchange instance = null;

        //En publik statisk property som retunerar instansen av Singleton klassen.
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

        //Privat konstruktor utan parametrar för att säkerställa att klassen endast kan instasieras inom klassen. 
        private CurrencyExchange()
        {
            //Här efterfrågas valutor och belopp som bestämms under runtime och som sedan sparas i properties
            Console.WriteLine("Ange vilken valuta du vill växla från: Euro, SEK eller USD");
            CurrencyToExchangeFrom = Console.ReadLine().ToUpper();
            Console.WriteLine("Ange vilken valuta du vill växla till: Euro, SEK eller USD");
            CurrencyToExchangeTo = Console.ReadLine().ToUpper();
            Console.WriteLine("Ange beloppet du vill växla: ");
            CurrencyAmount = int.Parse(Console.ReadLine());
            CurrencyExchangeRate = GetExchangeRate();
            Console.Clear();
        }
        private decimal GetExchangeRate()
        {
            return CurrencyToExchangeFrom switch
            {
                "SEK" => CurrencyToExchangeTo switch
                {
                    "EURO" => (decimal)(1 / 9.48),
                    "USD" => (decimal)(1 / 8.08),
                    "SEK" => 1 * 1,
                    _ => 0M,
                },
                "EURO" => CurrencyToExchangeTo switch
                {
                    "SEK" => (decimal)(1 * 9.48),
                    "USD" => (decimal)(1 / 0.85),
                    "EURO" => 1 * 1,
                    _ => 0M,
                },
                "USD" => CurrencyToExchangeTo switch
                {
                    "SEK" => (decimal)(1 * 8.08),
                    "EURO" => (decimal)(1 * 0.85),
                    "USD" => 1 * 1,
                    _ => 0M,
                },
                _ => 0M,
            };
        }

        //Metod för att skriva ut valda valutor samt belopp.
        public void PrintDetails()
        {
            if (CurrencyToExchangeTo == "SEK")
            {
                Console.WriteLine($"Du har valt att växla {CurrencyAmount} {CurrencyToExchangeFrom} till {Math.Round((CurrencyAmount * CurrencyExchangeRate))} {CurrencyToExchangeTo}");
            }
            else
            {
                Console.WriteLine($"Du har valt att växla {CurrencyAmount} {CurrencyToExchangeFrom} till {Math.Round((CurrencyAmount * CurrencyExchangeRate), 2)} {CurrencyToExchangeTo}");
            }
            Console.WriteLine(new string('-', 45));
        }
    }
}
