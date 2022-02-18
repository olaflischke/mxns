using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace HistoricalTradingDaysDal
{
    public class TradingDay
    {
        public TradingDay()
        {
        }

        public TradingDay(XElement xElement)
        {
            this.Date = Convert.ToDateTime(xElement.Attribute("time").Value);

            //CultureInfo ci = new CultureInfo("en-US");
            //NumberFormatInfo nfiEzb = ci.NumberFormat;

            NumberFormatInfo nfiEzb = new NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "" };

            var q = xElement.Elements().Select(el => new ExchangeRate()
            {
                Symbol = el.Attribute("currency").Value,
                EuroRate = Convert.ToDouble(el.Attribute("rate").Value, nfiEzb)
            });

            this.ExchangeRates = q.ToList();

        }

        public DateTime Date { get; set; }
        public List<ExchangeRate> ExchangeRates { get; set; }
    }
}