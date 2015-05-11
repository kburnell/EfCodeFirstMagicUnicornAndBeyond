using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Demo1.Domain;

namespace Demo1.DataContext {

    public class Demo1DataContext : DbContext {
        
        public Demo1DataContext() : base("name=MagicUnicorn_Demo1") {}

        public IDbSet<Manufacturer> Manufacturers { get; set; }
        public IDbSet<Model> Models { get; set; }
        public IDbSet<Engine> Engines { get; set; }

        public IDbSet<Part> Parts { get; set; }

        public IDbSet<Option> Options { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            modelBuilder.Entity<Model>().HasMany(x => x.AvailableEngines)
                  .WithMany(x => x.AvailableIn)
                  .Map(x => x.MapLeftKey("ModelId").MapRightKey("EngineId").ToTable("ModelAvailableEngines"));


            modelBuilder.Entity<Manufacturer>().Property(x => x.Country).IsRequired().HasMaxLength(100);


            //Default Max Length to avoid VarChar Max
            modelBuilder.Properties()
                    .Where(property => property.PropertyType == typeof(string))
                    .Configure(config => config.HasMaxLength(100));

            //Default Strings to Non-Nullable
            modelBuilder.Properties()
                    .Where(property => property.PropertyType == typeof(string))
                    .Configure(config => config.IsRequired());



            //Add Custom Primary Key Convention
            modelBuilder.Properties()
                    .Where(prop => prop.Name.EndsWith("Key"))
                    .Configure(config => config.IsKey());

            modelBuilder.Entity<Option>().MapToStoredProcedures();
            
            
            
            
            base.OnModelCreating(modelBuilder);
        }
            
    }
}