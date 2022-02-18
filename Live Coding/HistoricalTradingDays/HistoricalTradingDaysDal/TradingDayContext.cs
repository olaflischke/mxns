using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalTradingDaysDal
{
    public class TradingDayContext : DbContext
    {
        public TradingDayContext() :
            base("name=TradingDayContext")
        {

        }

        public DbSet<TradingDay> TradingDays { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
