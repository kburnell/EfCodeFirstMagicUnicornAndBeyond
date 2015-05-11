﻿using System.Collections.Generic;

namespace Demo1.Domain {

    public class Manufacturer {

        public long Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public ICollection<Model> Models { get; set; }

    }
}