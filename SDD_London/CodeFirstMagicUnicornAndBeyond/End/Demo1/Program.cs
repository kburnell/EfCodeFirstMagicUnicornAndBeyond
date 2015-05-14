using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Demo1.DataContext;
using Demo1.Domain;

namespace Demo1 {

    class Program {
        static void Main(string[] args) {

            Database.SetInitializer(new DataContextInitializer());
            using (var context = new Demo1DataContext())
            {
                //THIS IS DEMO-WARE --- DO NOT DO THIS IN PRODUCTION -- Please Have a Proper Data Access Layer!!!!
                IList<Manufacturer> manufacturers = context.Manufacturers.ToList();
                Console.WriteLine(string.Format("Ferrari is {0} miles from Lamborghini.", Math.Round(manufacturers[0].Location.Distance(manufacturers[1].Location).Value / 1609.344, 2)));
            }

            Console.WriteLine("Tada!");

            
            Console.ReadKey();
            
        }

            


    }
}