using System;

namespace EF_Mappings
{
    class ListContinents
    {
        static void Main(string[] args)
        {
            var contex = new GeographyEntities();

            foreach (var continent in contex.Continents)
            {
                Console.WriteLine(continent.ContinentName);
            }
        }
    }
}
