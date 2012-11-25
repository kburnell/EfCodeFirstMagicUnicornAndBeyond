using System.Collections.Generic;

namespace Demo1.Domain {

    public class Model {

        public long Id{ get; set; }

        public string Name{ get; set; }

        public int Year { get; set; }

        public decimal BasePrice { get; set; }

        public long ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Engine> AvailableEngines { get; set; }

    }
}