using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EF6_Beta_Demo.Models;

namespace EF6_Beta_Demo.DataContext {

    public class EF6DemoDataContext : DbContext {
        
        public EF6DemoDataContext() : base("name=EF6Beta_Demo") {}

        public IDbSet<Manufacturer> Manufacturers { get; set; }
        public IDbSet<Model> Models { get; set; }
        public IDbSet<Engine> Engines { get; set; }
        //public IDbSet<Part> Parts { get; set; } 


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            RegisterCustomConventions(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Model>().HasMany(x => x.AvailableEngines)
                  .WithMany(x => x.AvailableIn)
                  .Map(x => x.MapLeftKey("ModelId").MapRightKey("EngineId").ToTable("ModelAvailableEngines"));
            modelBuilder.Entity<Manufacturer>().Property(x => x.Country).IsRequired().HasMaxLength(100);
            
            base.OnModelCreating(modelBuilder);
        }

        private void RegisterCustomConventions(DbModelBuilder modelBuilder) {
            //Default Max Length to avoid VarChar Max
            modelBuilder.Conventions.Add(
                entities => entities.Properties()
                    .Where(property => property.PropertyType == typeof(string))
                    .Configure(config => config.MaxLength = 100));

            //Default Strings to Non-Nullable
            modelBuilder.Conventions.Add(
                entities => entities.Properties()
                    .Where(property => property.PropertyType == typeof(string))
                    .Configure(config => config.IsNullable = false));



            //Add Custom Primary Key Convention
            modelBuilder.Conventions.Add(
                entities => entities.Properties()
                    .Where(prop => prop.Name.EndsWith("Key"))
                    .Configure(config => config.IsKey()));


        }
    }
}