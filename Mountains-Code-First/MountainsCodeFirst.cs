namespace Mountains_Code_First
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    class MountainsCodeFirst
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MountainsMigrationStrategy());

            var context = new MountainsContext();
            var countriesQuery = context.Countries.Select(c => new
            {
                c.Name,
                Mountains = c.Mountains.Select(m => new
                {
                    m.Name,
                    m.Peaks,
                })
            });

            foreach (var country in countriesQuery)
            {
                Console.WriteLine("Country :" + country.Name);
                foreach (var mountain in country.Mountains)
                {
                    Console.WriteLine("Mountain: " + mountain.Name);
                    foreach (var peak in mountain.Peaks)
                    {
                        Console.WriteLine("\t{0} ({1})" ,peak.Name,peak.Elevation);
                    }

                }

            }
        }
    }
}
