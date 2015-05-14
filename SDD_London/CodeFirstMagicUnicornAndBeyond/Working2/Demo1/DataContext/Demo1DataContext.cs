using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Demo1.Domain;

namespace Demo1.DataContext {

    public class Demo1DataContext : DbContext {
        
        public Demo1DataContext() : base("name=MagicUnicorn_Demo1") {}



        public IDbSet<Manufacturer> Manufacturers { get; set; }
        public IDbSet<Model> Models { get; set; }
        public IDbSet<Engine> Engines { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();



            modelBuilder.Entity<Model>().HasMany(x => x.AvailableEngines)
                  .WithMany(x => x.AvailableIn)
                  .Map(x => x.MapLeftKey("ModelId").MapRightKey("EngineId").ToTable("ModelAvailableEngines"));
            
            
            

            base.OnModelCreating(modelBuilder);
        }


            

    }
}