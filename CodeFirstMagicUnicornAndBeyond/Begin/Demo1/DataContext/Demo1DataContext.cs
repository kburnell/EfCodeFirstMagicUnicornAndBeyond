using System.Data.Entity;
using Demo1.Domain;

namespace Demo1.DataContext {

    public class Demo1DataContext : DbContext {
        
        public Demo1DataContext() : base("name=MagicUnicorn_Demo1") {}

        public IDbSet<Manufacturer> Manufacturers { get; set; }
        public IDbSet<Model> Models { get; set; }
        public IDbSet<Engine> Engines { get; set; }

    }
}