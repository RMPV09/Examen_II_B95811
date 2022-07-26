using Examen_II_B95811.Data;
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

        public IActionResult Index()
        {
            Database myData = new Database();
            ViewBag.MainTitle = "Drinks choices";
            var sodas = myData.GetSodas();
            return View(sodas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}