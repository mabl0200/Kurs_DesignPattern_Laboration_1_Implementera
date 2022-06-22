using FactoryMethod;
using Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public interface INotesCalculations
    {
        List<decimal> Notes { get; }
        void CalculateAmountOfNotes(CurrencyExchange exchange, ICurrency currency);
    }
    
    public class GetUsdNotes : INotesCalculations
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
                        Console.WriteLine($"{counter} st {value * 100} cent");
                    }
                }
            }
        }
    }

    public class GetSekNotes : INotesCalculations
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

    public class GetEuroNotes : INotesCalculations
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
                        Console.WriteLine($"{counter} st {value * 100} cent");
                    }
                }
            }
        }
    }
    public class NoteContext
    {
        private INotesCalculations _notesCalculations;

        public NoteContext(INotesCalculations notesCalculations)
        {
            this._notesCalculations = notesCalculations;
        }
        public void DoCalulations(CurrencyExchange exchange, ICurrency currency)
        {
            _notesCalculations.CalculateAmountOfNotes(exchange, currency);
        }
    }
}
