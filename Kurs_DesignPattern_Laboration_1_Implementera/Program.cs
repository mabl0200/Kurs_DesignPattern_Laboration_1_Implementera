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
            //Anropar Singleton-klassen för att skapa en ny instans av en Valutaväxling
            CurrencyExchange exchange = CurrencyExchange.GetInstance;
            exchange.PrintDetails();

            //Anropar FactoryMethod för att hämta information om vald valuta att växla till
            //Kollar vilken factory som ska användas med hjälp av Singleton objektet.
            ICurrencyFactory toFactory = GetFactory(exchange.CurrencyToExchangeTo);


            //Anropar Strategy-klassen för att göra beräkningarna för att se vilka sedlar som klienten får vid växling.
            NoteContext noteContext = (NoteContext)GetNoteContext(exchange.CurrencyToExchangeTo);
            noteContext.DoCalulations(exchange, toFactory.GetCurrency());
            
        }
        public static ICurrencyFactory GetFactory(string currency)
        {
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
                "SEK" => new NoteContext(new GetSekNotes()),
                "EURO" => new NoteContext(new GetEuroNotes()),
                "USD" => new NoteContext(new GetUsdNotes()),
                _ => null,
            };
        }
    }
}
