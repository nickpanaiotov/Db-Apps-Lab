namespace Import_Rivers_From_XML
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using EF_Mappings;
    class ImportRiversFromXml
    {
        static void Main()
        {
            var xmlDoc = XDocument.Load(@"..\..\rivers.xml");
            var riverNodes = xmlDoc.XPathSelectElements("rivers/river");
            foreach (var riverNode in riverNodes)
            {
                string riverName = riverNode.Element("name").Value;
                int riverLenght = int.Parse(riverNode.Element("length").Value);
                string riverOutflow = riverNode.Element("outflow").Value;

                int? drainageArea = null;
                if (riverNode.Element("drainage-area") != null)
                {
                    drainageArea = int.Parse(riverNode.Element("drainage-area").Value);
                }

                int? averageDisaverage = null;
                if (riverNode.Element("average-discharge") != null)
                {
                    averageDisaverage = int.Parse(riverNode.Element("average-discharge").Value);
                }

                var contex = new GeographyEntities();
                var river = new River()
                {
                    RiverName = riverName,
                    Length = riverLenght,
                    Outflow = riverOutflow,
                    DrainageArea = drainageArea,
                    AverageDischarge = averageDisaverage
                };
                
                var countryNodes = riverNode.XPathSelectElements("countries/country");
                var countriyNames = countryNodes.Select(c => c.Value);
                foreach (var countryName in countriyNames)
                {
                    var country = contex.Countries.FirstOrDefault(c => c.CountryName == countryName);
                    river.Countries.Add(country);
                }

                contex.Rivers.Add(river);
                contex.SaveChanges();
            }
        }
    }
}
