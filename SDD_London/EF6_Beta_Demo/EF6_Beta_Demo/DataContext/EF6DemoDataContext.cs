using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EF6_Beta_Demo.Models;

namespace EF6_Beta_Demo.DataContext {

    public class EF6DemoDataContext : DbContext {
        
        public EF6DemoDataContext() : base("name=EF6Beta_Demo") {}

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
        public virtual IDbSet<Model> Models { get; set; }
        public virtual IDbSet<Engine> Engines { get; set; }
        //public virtual IDbSet<Part> Parts { get; set; } 


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //RegisterCustomConventions(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Model>().HasMany(x => x.AvailableEngines)
                  .WithMany(x => x.AvailableIn)
                  .Map(x => x.MapLeftKey("ModelId").MapRightKey("EngineId").ToTable("ModelAvailableEngines"));
            
            base.OnModelCreating(modelBuilder);
        }

        private void RegisterCustomConventions(DbModelBuilder modelBuilder) {
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

        }

        #region -- The Gateway To Hell... Keep Closed! --

        private void OpenTheGates(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Manufacturer>().MapToStoredProcedures();
        }

        #endregion
    }
}