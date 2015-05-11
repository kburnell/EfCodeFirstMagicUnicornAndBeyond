using System.Collections.Generic;
using System.Linq;
using EF6_Beta_Demo.DataContext;
using EF6_Beta_Demo.Models;

namespace EF6_Beta_Demo.Services {

    public class ManufacturerService {

        private readonly EF6DemoDataContext _context;

        public ManufacturerService(EF6DemoDataContext context) {
            _context = context;
        }

        public IList<Manufacturer> GetAll() {
            return _context.Manufacturers.OrderBy(x => x.Name).ToList();
        }
    }
}