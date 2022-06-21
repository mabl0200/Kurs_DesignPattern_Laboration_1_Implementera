using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    //Product Interface
    public interface ICurrency
    {
        
        string Currency { get; }
        string Symbol { get; }
        decimal[] GetNotes();
        List<decimal> GetNote();
        //decimal[] ValueOfNotes { set; }
    }

    //Product class
    public class Euro : ICurrency
    {
        public string Currency => "Euro";

        public string Symbol => "€";

        public List<decimal> GetNote()
        {
            return new List<decimal>() { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.50M, 0.20M, 0.10M, 0.05M, 0.02M, 0.01M };
        }

        public decimal[] GetNotes()
        {
            return new decimal[] { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.50M, 0.20M, 0.10M, 0.05M, 0.02M, 0.01M};
            
        }
    }
    public class Sek : ICurrency
    {
        public string Currency => "SEK";

        public string Symbol => "kr";

        public List<decimal> GetNote()
        {
            return new List<decimal>() { 500, 100, 50, 20, 10, 1 };
        }

        public decimal[] GetNotes()
        {
            return new decimal[] { 500, 100, 50, 20, 10, 1 };
        }
    }
    public class Usd : ICurrency
    {
        public string Currency => "USD";

        public string Symbol => "$";

        public List<decimal> GetNote()
        {
            return new List<decimal>() { 100, 50, 20, 10, 5, 2, 1, 0.50M, 0.25M, 0.10M, 0.05M, 0.01M };
        }

        public decimal[] GetNotes()
        {
            return new decimal[] { 100, 50, 20, 10, 5, 2, 1, 0.50M, 0.25M, 0.10M, 0.05M, 0.01M };
        }
    }
}
