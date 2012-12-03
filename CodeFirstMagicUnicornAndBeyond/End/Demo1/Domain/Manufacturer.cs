﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Spatial;

namespace Demo1.Domain {

    public class Manufacturer {

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Country { get; set; }

        public DbGeography Location { get; set; }

        public double GrossRevenue { get; set; }

        public ICollection<Model> Models { get; set; }

    }
}