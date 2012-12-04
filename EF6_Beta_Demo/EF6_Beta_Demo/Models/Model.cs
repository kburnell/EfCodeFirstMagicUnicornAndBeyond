using System.Collections.Generic;
using EF6_Beta_Demo.Enumerations;

namespace EF6_Beta_Demo.Models {

    public class Model {

        public long Id{ get; set; }

        public string Name{ get; set; }

        public int Year { get; set; }

        public decimal BasePrice { get; set; }

        public EngineLocationType EngineLocation { get; set; }

        public long ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Engine> AvailableEngines { get; set; }

    }
}