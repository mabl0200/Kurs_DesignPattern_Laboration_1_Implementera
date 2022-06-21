using Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    //The Factory
    interface ICurrencyConverter
    {
        CurrencyExchange currencyExhange { get; }
        string GetCurrencyToExchangeFrom();
        string GetCurrencyToExchangeTo();
        decimal GetAmount();
    }
}
