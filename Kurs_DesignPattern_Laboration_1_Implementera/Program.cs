using FactoryMethod;
using Singleton;
using Strategy;
using System;

namespace Kurs_DesignPattern_Laboration_1_Implementera
{
    class Program
    {
        static void Main(string[] args)
        {
            //Jag har valt att använda Singleton, Factory Method och Strategy

            //Anropar Singleton-klassen för att skapa en ny instans av en Valutaväxling
            CurrencyExchange exchange = CurrencyExchange.GetInstance;
            exchange.PrintDetails();
            
            //Använder metoden GetFactory med Singleton objektet som parameter för att ta reda på vilken Factory class som ska instansieras.
            ICurrencyFactory toFactory = GetFactory(exchange.CurrencyToExchangeTo);
            
            //Använder metoden GetNoteContext med Singleton objektet som parameter för att ta reda på vilken kontext class som ska instansieras.
            NoteContext noteContext = (NoteContext)GetNoteContext(exchange.CurrencyToExchangeTo);
            //Anropar Strategy-klassen för att göra beräkningarna för att se vilka sedlar som klienten får vid växling.
            noteContext.DoCalulations(exchange, toFactory.GetCurrency());
            
        }
        public static ICurrencyFactory GetFactory(string currency)
        {
            //Instansierar ett nytt objekt från en fabrik
            return currency switch
            {
                "SEK" => new SekFactory(),
                "EURO" => new EuroFactory(),
                "USD" => new UsdFactory(),
                _ => null,
            };
        }
        public static NoteContext GetNoteContext(string context)
        {
            return context switch
            {
                "SEK" => new NoteContext(new SekNotes()),
                "EURO" => new NoteContext(new EuroNotes()),
                "USD" => new NoteContext(new UsdNotes()),
                _ => null,
            };
        }
    }
}
