using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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
            // Typdeklaration durch Wertzuweisung
            // "type inference"
            var a = new TradingDay();

            //List<TradingDay> days = new List<TradingDay>();

            XDocument document = XDocument.Load(url);

            var q = from nd in document.Root.Descendants()
                    where nd.Name.LocalName == "Cube" && nd.Attributes().Any(at => at.Name == "time")
                    // Projektion
                    select new TradingDay(nd); //{ Date = Convert.ToDateTime(nd.Attribute("time").Value) };

            var q2 = document.Root.Descendants().Where(nd => nd.Name.LocalName == "Cube" && nd.Attributes().Any(at => at.Name == "time"))
                                                .Select(nd => new TradingDay(nd));

            //var q2 = document.Root.Descendants().Where(nd => { 
            //                                                    if (nd.Name.LocalName == "Cube" && nd.Attributes().Count() == 1)
            //                                                    {
            //                                                        return true;
            //                                                    }

            //                                                    return false;
            //                                                })
            //                                    .Select(nd => new TradingDay(nd));

            //var q2 = document.Root.Descendants().Where(nd => CheckElement(nd))
            //                                   .Select(nd => new TradingDay(nd));

            List<TradingDay> days = q.ToList();

            //foreach (XElement item in q)
            //{
            //    TradingDay day = new TradingDay() { Date = Convert.ToDateTime(item.Attribute("time").Value) };
            //    days.Add(day);
            //}

            return days;
        }

        private bool CheckElement(XElement nd)
        {
            if (nd.Name.LocalName == "Cube" && nd.Attributes().Count() == 1)
            {
                return true;
            }

            return false;
        }

        private List<TradingDay> GetDataXmlReader(string url)
        {
            XmlReader xmlReader = XmlReader.Create(url);

            List<TradingDay> days = new List<TradingDay>();

            while (xmlReader.Read())
            {
                if (xmlReader.Name == "Cube")
                {
                    TradingDay day = null;

                    if (xmlReader.AttributeCount == 1)
                    {
                        day = new TradingDay();
                        day.Date = Convert.ToDateTime(xmlReader.GetAttribute("time"));
                    }

                    if (xmlReader.AttributeCount == 2)
                    {
                        ExchangeRate rate = new ExchangeRate()
                        {
                            EuroRate = Convert.ToDouble(xmlReader["rate"]),
                            Symbol = xmlReader["currency"]
                        };

                        day.ExchangeRates.Add(rate);
                    }

                    if (day != null)
                    {
                        days.Add(day);
                    }
                }
            }

            return days;
        }


        public List<TradingDay> TradingDays { get; set; }

    }
}
