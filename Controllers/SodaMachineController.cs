using Examen_II_B95811.Data;
using Examen_II_B95811.Handlers;
using Examen_II_B95811.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Examen_II_B95811.Controllers
{
    public class SodaMachineController : Controller
    {
        private readonly ILogger<SodaMachineController> _logger;
        public SodaMachineController(ILogger<SodaMachineController> logger)
        {
            _logger = logger;
        }

        public IActionResult ShowSodas()
        {
            ViewBag.MainTitle = "Drinks choices";
            ViewModel mymodel = new ViewModel();  
            SodasHandler myHandler = new SodasHandler();
            mymodel.SodaList = myHandler.GetAllSodas();
            mymodel.ASoda = new SodaModel();
            if (TempData["shortMessage"] != null)
            {
                ViewBag.Message = TempData["shortMessage"].ToString();

            }
            else 
            {
                ViewBag.Message = "Record Inserted successfully!!!";
            }
            return View(mymodel);
        }

        [HttpGet]
        public IActionResult PayForSodas()
        {
            return RedirectToAction("ShowSodas");
        }

        [HttpPost]
        public IActionResult PayForSodas(ViewModel mySoda)
        {
            ViewBag.Success = false;
            try
            {
                if (mySoda.ASoda != null)
                {
                    SodaModel mySodaModel = new SodaModel();
                    mySodaModel = mySoda.ASoda; 
                    SodasHandler mySodasHandler = new SodasHandler();
                    ViewBag.Success = mySodasHandler.ModifyInventoryOfSodas(mySodaModel);
                    if (ViewBag.Success) 
                    {
                        ViewBag.Message = "There is success!";
                        ModelState.Clear();
                    }
                }
                TempData["shortMessage"] = "MyMessage";
                //ViewBag.Message = "Record Inserted successfully";
                

                return RedirectToAction("ShowSodas");
            }
            catch 
            {
                ViewBag.Message = "There is NOT success!";
                return View();

                //return RedirectToAction("ShowSodas");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}