using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mountains_Code_First
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MountainsContext : DbContext
    {
        // Your context has been configured to use a 'MountainsContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Mountains_Code_First.MountainsContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MountainsContext' 
        // connection string in the application configuration file.
        public MountainsContext()
            : base("name=MountainsContext")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Mountain> Mountains { get; set; }
        public virtual DbSet<Peak> Peaks { get; set; }

    }

    public class Country
    {
        public Country()
        {
            this.Mountains = new HashSet<Mountain>();
        }

        [Key]
        [StringLength(2, MinimumLength = 2)]
        [Column(TypeName = "char")]
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Mountain> Mountains { get; set; }
    }

    public class Mountain
    {
        public Mountain()
        {
            this.Countries = new HashSet<Country>();
            this.Peaks = new HashSet<Peak>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Peak> Peaks { get; set; }
    }

    public class Peak
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Elevation { get; set; }
        public virtual Mountain Mountain { get; set; }
    }
}