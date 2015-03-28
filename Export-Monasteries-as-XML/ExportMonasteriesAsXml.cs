namespace Export_Monasteries_as_XML
{
    using System.Linq;
    using System.Xml.Linq;
    using EF_Mappings;
    class ExportMonasteriesAsXml
    {
        static void Main()
        {
            var contex = new GeographyEntities();

            var contriesQuery = contex.Countries
                .Where(c=> c.Monasteries.Any())
                .OrderByDescending(c=>c.CountryName)
                .Select(c => new
            {
                c.CountryName,
                Monosteries = c.Monasteries
                    .OrderByDescending(m=>m.Name)    
                    .Select(m => m.Name)
            });

            var xmlMonasteries = new XElement("monasteries");
            foreach (var contry in contriesQuery)
            {
                var xmlContry = new XElement("country");
                xmlContry.Add(new XAttribute("name",contry.CountryName));
                xmlMonasteries.Add(xmlContry);

                foreach (var monastery in contry.Monosteries)
                {
                    xmlContry.Add(new XElement("monastery",monastery));
                }
            }
            var xmlDox = new XDocument(xmlMonasteries);
            xmlDox.Save("monasteries.xml");
        }
    }
}
