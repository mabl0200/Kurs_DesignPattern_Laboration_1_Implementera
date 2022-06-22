using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    //Product Interface
    public interface ICurrency
    {
        string Currency { get; }
        string Symbol { get; }
    }

    //Product class med olika valutor
    public class Euro : ICurrency
    {
        public string Currency => "EURO";
        public string Symbol => "€";
    }
    public class Sek : ICurrency
    {
        public string Currency => "SEK";
        public string Symbol => "kr";
    }
    public class Usd : ICurrency
    {
        public string Currency => "USD";
        public string Symbol => "$";
    }
}
