using FactoryMethod;
using Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    //The Strategy
    public interface INotes
    {
        List<decimal> Notes { get; }
        void CalculateAmountOfNotes(CurrencyExchange exchange, ICurrency currency);
    }
    
    //Konkreta strategiklasser som implementerar interfacet. 
    public class UsdNotes : INotes
    {
        public List<decimal> Notes
        {
            get
            {
                return new List<decimal>() { 100, 50, 20, 10, 5, 2, 1, 0.50M, 0.25M, 0.10M, 0.05M, 0.01M };
            }
        }

        public void CalculateAmountOfNotes(CurrencyExchange exchange, ICurrency currency)
        {
            decimal sum = (exchange.CurrencyAmount * exchange.CurrencyExchangeRate);
            Console.WriteLine($"Du får {Math.Round(sum, 2)} {currency.Symbol} i dessa valörer:");
            foreach (var value in Notes)
            {
                int counter = 0;
                while (Math.Round(sum, 2) >= value)
                {
                    sum = sum - value;
                    counter++;
                }
                if (counter > 0)
                {
                    if (value >= 1)
                    {
                        Console.WriteLine($"{counter} st {value} {currency.Symbol}");
                    }
                    else
                    {
                        Console.WriteLine($"{counter} st {Math.Round(value * 100)} cent");
                    }
                }
            }
        }
    }

    public class SekNotes : INotes
    {
        public List<decimal> Notes
        {
            get
            {
                return new List<decimal>() { 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };
            }
        }

        public void CalculateAmountOfNotes(CurrencyExchange exchange, ICurrency currency)
        {
            decimal sum = (exchange.CurrencyAmount * exchange.CurrencyExchangeRate);
            Console.WriteLine($"Du får {Math.Round(sum, 2)} {currency.Symbol} i dessa valörer:");
            foreach (var value in Notes)
            {
                int counter = 0;
                while (Math.Round(sum) >= value)
                {
                    sum = sum - value;
                    counter++;
                }
                if (counter > 0)
                {
                    Console.WriteLine($"{counter} st {value} {currency.Symbol}");
                }
            }
        }
    }

    public class EuroNotes : INotes
    {
        public List<decimal> Notes
        {
            get
            {
                return new List<decimal>() { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.50M, 0.20M, 0.10M, 0.05M, 0.02M, 0.01M };
            }
        }

        public void CalculateAmountOfNotes(CurrencyExchange exchange, ICurrency currency)
        {
            decimal sum = (exchange.CurrencyAmount * exchange.CurrencyExchangeRate);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine($"Du får {Math.Round(sum, 2)} {currency.Symbol} i dessa valörer:");
            foreach (var value in Notes)
            {
                int counter = 0;
                while (Math.Round(sum, 2) >= value)
                {
                    sum = sum - value;
                    counter++;
                }
                if (counter > 0)
                {
                    if (value >= 1)
                    {
                        Console.OutputEncoding = System.Text.Encoding.Unicode;
                        Console.WriteLine($"{counter} st {value} {currency.Symbol}");
                    }
                    else
                    {
                        Console.WriteLine($"{counter} st {Math.Round(value * 100)} cent");
                    }
                }
            }
        }
    }

    //Kontextklassen som håller en referens till Strategi objektet och använder det för att anropa rätt Strategiklass för att göra rätt uträkning.
    public class NoteContext
    {
        private INotes _notes;

        public NoteContext(INotes notes)
        {
            this._notes = notes;
        }
        public void DoCalulations(CurrencyExchange exchange, ICurrency currency)
        {
            _notes.CalculateAmountOfNotes(exchange, currency);
        }
    }
}
