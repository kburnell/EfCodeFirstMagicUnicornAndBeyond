using System.Collections.Generic;

namespace Demo1.Domain {

    public class Engine {

        public long Id { get; set; }

        public string Name { get; set; }

        public int NumberOfCylinders { get; set; }

        public decimal Liters { get; set; }

        public long BreakHorsepower { get; set; }

        public ICollection<Model> AvailableIn { get; set; }

    }
}