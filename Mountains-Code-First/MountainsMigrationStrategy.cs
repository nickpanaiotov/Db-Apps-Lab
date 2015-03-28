using System.Data.Entity;

namespace Mountains_Code_First
{
    public class MountainsMigrationStrategy : DropCreateDatabaseIfModelChanges<MountainsContext>
    {
        protected override void Seed(MountainsContext context)
        {
            var bulgaria = new Country(){ Code = "BG", Name = "Bulgaria" };
            context.Countries.Add(bulgaria);
            var germany = new Country() { Code = "DE", Name = "Germany" };
            context.Countries.Add(germany);
            

            var staraPlanina = new Mountain() { Name = "Stara Planina", Countries = { bulgaria } };
            context.Mountains.Add(staraPlanina);

            var vryhBotev = new Peak() { Name = "Vryh Botev", Elevation = 2376, Mountain = staraPlanina };
            context.Peaks.Add(vryhBotev);

            var vryhKom = new Peak() { Name = "Vryh Kom", Elevation = 2015, Mountain = staraPlanina };
            context.Peaks.Add(vryhKom);
        }
    }
}
