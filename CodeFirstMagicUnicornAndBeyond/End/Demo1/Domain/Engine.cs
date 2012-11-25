using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo1.Domain {

    public class Engine {

        public long EngineId { get; set; }

        public string Name { get; set; }

        public int NumberOfCylinders { get; set; }

        public decimal Liters { get; set; }

        public long BreakHorsepower { get; set; }

        public ICollection<Model> AvailableIn { get; set; } 

    }
}