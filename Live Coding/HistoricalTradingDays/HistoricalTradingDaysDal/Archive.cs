using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalTradingDaysDal
{
    public class Archive
    {
        public Archive(string url)
        {
            this.TradingDays = GetData(url);
        }

        private List<TradingDay> GetData(string url)
        {
            // TODO: XML lesen implementieren
            throw new NotImplementedException();
        }

        public List<TradingDay> TradingDays { get; set; }

    }
}
