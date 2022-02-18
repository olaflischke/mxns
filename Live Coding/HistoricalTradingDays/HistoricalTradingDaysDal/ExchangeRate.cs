namespace HistoricalTradingDaysDal
{
    public class ExchangeRate
    {
        public double EuroRate { get; set; }
        public string Symbol { get; set; }
        public int Id { get; set; }
        public TradingDay TradingDay { get; set; }
    }
}