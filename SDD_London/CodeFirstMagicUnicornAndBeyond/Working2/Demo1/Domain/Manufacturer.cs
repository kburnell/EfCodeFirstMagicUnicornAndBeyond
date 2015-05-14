using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Spatial;

namespace Demo1.Domain {

    public class Manufacturer {

        public long Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Country { get; set; }

        public decimal GrossIncome { get; set; }

        public decimal NetIncome { get; set; }

        public DbGeography Location { get; set; }

        public ICollection<Model> Models { get; set; }

    }
}