using HistoricalTradingDaysDal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;

namespace TradingDayUnitTests
{
    [TestClass]
    public class ArchiveTests
    {
        //string url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist.xml";
        string url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";

        [TestMethod]
        public void IsArchiveInitializing()
        {
            Archive archive = new Archive(url);

            // "Strings are immutable!"
            //string hallo = "Hallo";
            //string welt = "Welt!";
            //string meldung = hallo + " " + welt;

            //StringBuilder builder = new StringBuilder("Hallo");
            //builder.Append(" ");
            //builder.Append("Welt!");
            //string meldung2 = builder.ToString();

            foreach (TradingDay item in archive.TradingDays)
            {
                //string.Format("{0:dd.MM.yyyy}", item.Date);

                Console.WriteLine($"Tradingday mit Datum {item.Date:dd.MM.yyyy} gefunden.");
            }

            // Testergebnis definieren
            Assert.AreEqual(GetDaysFromXml(url), archive.TradingDays.Count);
         }

        [TestMethod]
        public void AreCurrencyValuesCorrect()
        {
            Archive archive = new Archive(url);

            ExchangeRate usd = archive.TradingDays.FirstOrDefault()?.ExchangeRates?.FirstOrDefault();
            ExchangeRate zar = archive.TradingDays.FirstOrDefault()?.ExchangeRates?.LastOrDefault();

            // TODO: Dollarkurs an aktuellen Wert anpassen!
            Assert.AreEqual(1.137, usd?.EuroRate);
            Assert.AreEqual(16.9893, zar.EuroRate);
        }


        private int GetDaysFromXml(string url)
        {
            // TODO: Zahl der TradingDays in XML korrekt ermitteln
            return 64;
        }
    }
}
