using Singleton;
using System;

namespace Kurs_DesignPattern_Laboration_1_Implementera
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyExchange exchange = CurrencyExchange.GetInstance;
            exchange.PrintDetails();
            
        }
    }
}
