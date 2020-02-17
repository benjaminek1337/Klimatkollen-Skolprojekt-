using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Klimatkollen.Data;
using Klimatkollen.Models;
using Microsoft.AspNetCore.Http;
using Klimatkollen.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Klimatkollen.Controllers
{
    [Authorize(Roles = "Klimatobservatör,Admin,Superadmin")]
    public class ReportObservationController : Controller
    {
        private readonly IRepository db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserRepository userDb;
        private Task<IdentityUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        public ReportObservationController(IRepository repository, IUserRepository userRepository, UserManager<IdentityUser> userManager)
        {
            this.db = repository;
            this.userManager = userManager;
            this.userDb = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ReportObservationStep1()
        {
            //Hämtar MainCategories från db
            ViewBag.Categories = db.GetMainCategoriesFromDb();

            return View();
        }
        public IActionResult ReportObservationStep2(MainCategory mainCat)
        {
            if (mainCat.Id == 0)
            {
                //Stannar på samma sida om ingen kategori är vald. Ska inte gå men man vet aldrig
                return RedirectToAction("ReportObservationStep1");
            }

            //mainCat = db.GetMainCategoryFromId(mainCat.Id); //Hämtar Namn på MainCat Kan tas bort??
            ObservationViewModel ob = new ObservationViewModel() //Skapar ViewModel
            {
                mainCategory = db.GetMainCategoryFromId(mainCat.Id)
            };
            ViewBag.newList = db.GetCategoriesFromId(mainCat);

            //Skickar tillbaka en vymodell
            return View(ob);
        }

        public IActionResult ReportObservationStep3(ObservationViewModel model)
        {
            model.category = db.GetCategoryFromId(model.category.Id);
            Observation o = new Observation()
            {
                //Laddar dagens datum som default
                Date = DateTime.Today,
                maincategoryId = model.mainCategory.Id
            };
            model.observation = o;

            //Hämtar underkategori baserat på vad som valts
            var list = db.GetThirdCategories(model.category);
            ViewBag.IsValueEnable = CheckList(list);

            ViewBag.thirdCategories = list;
            int thirdCategoriesCount = list.Count();
            ViewBag.thirdCategoriesCount = thirdCategoriesCount;

            if (model.category.Unit.Equals("Päls"))
            {
                //filtrerar listan om det gäller päls
                ViewBag.thirdCategories = list.Where(x => x.Unit.Equals("Päls"));
                ViewBag.environment = list.Where(x => x.Unit.Equals("Miljö"));
            }

            model.measurement.categoryId = model.category.Id;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReportObservationCompleted(ObservationViewModel model, string secondMeasurement)
        {
            model.measurement.categoryId = model.category.Id;
            //Hämtar inloggad user
            var user = await GetCurrentUserAsync();
            string userId = user?.Id;
            var person = userDb.GetPerson(userId);

            //Sätter värden
            model.observation.Person = person;
            model.measurement.Observation = model.observation;
            
            //Sparar i DB
            //db.AddObjectToDb(model.observation);
            db.AddObjectToDb(model.measurement);

            //Lägg till en andra measurement
            if (secondMeasurement != null)
            {
                int id = db.GetLastObservationIdFromUser(person);

                Measurement m = new Measurement()
                {
                    thirdCategoryId =  Convert.ToInt32(secondMeasurement),
                    observationId = id,
                    categoryId = model.category.Id
                };
                db.AddObjectToDb(m);
            }

            return View();
        }
        private bool CheckList(List<ThirdCategory> list)
        {
            if (list.Any(x => x.Unit.Contains("Päls")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}