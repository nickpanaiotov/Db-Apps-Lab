using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using EF_Mappings;

namespace Export_Rivers_as_JSON
{
    class ExportRiversAsJson
    {
        static void Main(string[] args)
        {
            var contex = new GeographyEntities();
            var riversQuery = contex.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
            {
                r.RiverName,
                r.Length,
                Contries = r.Countries
                    .OrderByDescending(c => c.CountryName)
                    .Select(c => c.CountryName)
            });

            var jsSerializer = new JavaScriptSerializer();
            var riverJson = jsSerializer.Serialize(riversQuery.ToList());
            Console.WriteLine(riverJson);

            File.WriteAllText("C:\\SQlite\\rivers.json", riverJson);
        }
    }
}
