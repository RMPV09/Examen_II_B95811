using Examen_II_B95811.Data;
using Examen_II_B95811.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Examen_II_B95811.Controllers
{
    public class SodaMachineController : Controller
    {
        private readonly ILogger<SodaMachineController> _logger;
        private Database myData = new Database();

        public SodaMachineController(ILogger<SodaMachineController> logger)
        {
            _logger = logger;
        }

        public IActionResult ShowSodas()
        {
            ViewBag.MainTitle = "Drinks choices";
            var sodas = myData.GetSodas();
            return View(sodas);
        }

        public IActionResult PayForSodas(SodaModel mySoda, int amount)
        {
            myData.RemoveSodas(mySoda, amount);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}