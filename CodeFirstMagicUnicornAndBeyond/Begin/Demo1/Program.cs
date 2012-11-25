using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Demo1.DataContext;
using Demo1.Domain;

namespace Demo1 {

    class Program {
        static void Main(string[] args) {
            Database.SetInitializer(new DataContextInitializer());
            Demo1DataContext context = new Demo1DataContext();
            ICollection <Manufacturer> manufacturers = context.Manufacturers.ToList();
        }
    }
}