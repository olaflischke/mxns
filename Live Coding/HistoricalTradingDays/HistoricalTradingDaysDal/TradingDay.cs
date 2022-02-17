using System;
using System.Collections.Generic;


namespace HistoricalTradingDaysDal
{
    public class TradingDay
    {
        public DateTime Date { get; set; }
        public List<ExchangeRate> ExchangeRates { get; set; }
    }
}