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
        private Database _myData = new Database();
        public SodaMachineController(ILogger<SodaMachineController> logger)
        {
            _logger = logger;
        }

        public IActionResult ShowSodas(Database a)
        {
            SodasHandler myHandler = new SodasHandler();
            var myTempVar = myHandler.GetAllSodas();
            return View(myTempVar);
            /*
            ViewBag.MainTitle = "Drinks choices";
            if (a.Sodas.Count == 0) 
            {
                ViewBag.Message = "Success!";
            }
            _myData.Sodas = _myData.SetDatabase();
            isFirstTime = false;
            
            return View(_myData.Sodas);
            */

        }

        [HttpGet]
        public IActionResult PayForSodas()
        {
            return RedirectToAction("ShowSodas");
        }

        [HttpPost]
        public IActionResult PayForSodas(SodaModel mySoda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //int index = _myData.GetIndexBySoda(mySoda.Name);
                    //int amount = mySoda.CansAvailable;
                    //_myData.Sodas = _myData.RemoveSodas(amount, index);
                    //_myData.Sodas.ElementAt(0).Name = "Hola";
                    ViewBag.Message = "Success!";
                    ModelState.Clear();

                }
                Database _myData2 = new Database();
                _myData2.Sodas = _myData2.SetDatabase();
                _myData2.Sodas.ElementAtOrDefault(0).Name = "Holiwis";
                return RedirectToAction("ShowSodas", new { Database = _myData2 } );
            }
            catch 
            {
                ViewBag.Message = "Failure!";
                return RedirectToAction("ShowSodas");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}