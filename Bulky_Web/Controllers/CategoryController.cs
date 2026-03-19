using Bulky_Web.Data;
using Bulky_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky_Models.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        //construtor 
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> lijstje = _db.Categories.ToList();
            //_db.categories is de tabel in de database, en .ToList() zet het om in een lijst van categorieën
            //zet elke rij uoit de tabel om in een obejct van de klasse category
            //en die objecten worden dan in een lijst gestopt 
            return View(lijstje);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category cat)
        {
            if (cat.Name == cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "naam en volgorde mogen niet dezelfde zijn");
            }
            if (cat.Name != null && cat.Name.ToLower() == "testje")
            {
                ModelState.AddModelError("", "De naam mag niet testje zijn");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(cat);
                _db.SaveChanges();
                TempData["success"] = "Categorie succesvol aangemaakt";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Als de id niet leeg is of niet 0, dan zoeken we de categorie die voldoet aan de Id
            //3 manieren om te zoeken

            //Category catFromDb = _db.Categories.Find(id); //WERKT ALLEEN OP PK
            //Category catFromDb = _db.Categories.FirstOrDefault(c => c.Id == id); //Zoek de eerste rij die voldoet aan de VW
            Category catFromDb = _db.Categories.Where(c => c.Id == id).FirstOrDefault(); //Zoek de eerste rij die voldoet aan de VW

            if (catFromDb == null)
            {
                return NotFound();
            }
            return View(catFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(cat);
                _db.SaveChanges();
                TempData["success"] = "Categorie succesvol gewijzigd";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }


        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category catFromDb = _db.Categories.Where(c => c.Id == id).FirstOrDefault(); //Zoek de eerste rij die voldoet aan de VW

            if (catFromDb == null)
            {
                return NotFound();
            }
            return View(catFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Category cat = _db.Categories.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(cat);
            _db.SaveChanges();
            TempData["success"] = "Categorie succesvol verwijderd";
            return RedirectToAction("Index", "Category");

        }
    }
}
