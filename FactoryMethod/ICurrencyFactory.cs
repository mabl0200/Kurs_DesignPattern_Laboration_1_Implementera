using Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    //The Factory som retunerar ett objekt av ICurrency
    public interface ICurrencyFactory
    {
        ICurrency GetCurrency();
    }

    //Factory klasser 
    public class EuroFactory : ICurrencyFactory
    {
        public ICurrency GetCurrency()
        {
            return new Euro();
        }
    }
    public class SekFactory : ICurrencyFactory
    {
        public ICurrency GetCurrency()
        {
            return new Sek();
        }
    }
    public class UsdFactory : ICurrencyFactory
    {
        public ICurrency GetCurrency()
        {
            return new Usd();
        }
    }
    
}
