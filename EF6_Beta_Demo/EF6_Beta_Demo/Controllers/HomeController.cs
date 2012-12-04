using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using EF6_Beta_Demo.DataContext;
using EF6_Beta_Demo.Models;

namespace EF6_Beta_Demo.Controllers {

    public class HomeController : Controller {

        private readonly EF6DemoDataContext _db;

        public HomeController() {
            Database.SetInitializer(new DataContextInitializer());
            _db = new EF6DemoDataContext();
        }

        public ActionResult Index() {
            return View();
        }

        public async Task<ActionResult> AllManufacturersAsync() {
            List<Manufacturer> model = await _db.Manufacturers.ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> EditAsync(int id) {
            Manufacturer model = await _db.Manufacturers.FindAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditAsync(Manufacturer manufacturer) {
            if (ModelState.IsValid) {
                _db.Entry(manufacturer).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }
    }
}