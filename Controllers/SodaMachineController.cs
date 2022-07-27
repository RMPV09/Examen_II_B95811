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
            ViewModel mymodel = new ViewModel();  
            SodasHandler myHandler = new SodasHandler();
            mymodel.SodaList = myHandler.GetAllSodas();
            mymodel.ASoda = new SodaModel();
            if (TempData["shortMessage"] != null)
            {
                ViewBag.Message = TempData["shortMessage"].ToString();

            }
            return View(mymodel);
        }

        [HttpGet]
        public IActionResult PlaceOrder()
        {
            return RedirectToAction("ShowSodas");
        }

        [HttpPost]
        public IActionResult PlaceOrder(ViewModel mySoda)
        {
            ViewBag.Success = false;
            try
            {
                if (mySoda.ASoda != null)
                {
                    ValidateOrder(mySoda);
                }
                else 
                {
                    TempData["shortMessage"] = "There has been an error, please choose an existing Soda name";
                }

                return RedirectToAction("ShowSodas");
            }
            catch 
            {
                TempData["shortMessage"] = "There has been an error with the machine. Please reboot";
                return RedirectToAction("ShowSodas");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void ValidateOrder(ViewModel mySoda) 
        {
            SodaModel mySodaModel = new SodaModel();
            mySodaModel = mySoda.ASoda;
            SodasHandler mySodasHandler = new SodasHandler();
            int cansToBeBought = TryToBuy(mySodasHandler.GetAllSodas(), mySodaModel.CansAvailable, mySodaModel.Name);
            if (cansToBeBought != -1)
            {
                mySodaModel.CansAvailable = cansToBeBought;
                ViewBag.Success = mySodasHandler.ModifyInventoryOfSodas(mySodaModel);
                TempData["shortMessage"] = "Soda " + mySodaModel.Name + " has been bought";
            }
            else
            {
                TempData["shortMessage"] = "Soda " + mySoda.ASoda.Name + " has NOT been bought. Please check the name and amount of chosen cans";
            }
        }

        private int TryToBuy(List<SodaModel> mySodaList,int amount, string Name)
        {
            int boughtCans = -1;
            int cansLeft;
            int index;
            if (amount > 0) 
            {
                index = CalculateCanNameIndex(mySodaList, Name);
                cansLeft = CalculateCansLeft(mySodaList, index);
                if (cansLeft > 0) 
                {
                    boughtCans = cansLeft - amount;
                }
            }
            return boughtCans;
        }

        private int CalculateCansLeft(List<SodaModel> mySodaList, int index) 
        {
            return mySodaList.ElementAtOrDefault(index).CansAvailable;
        }

        private int CalculateCanNameIndex(List<SodaModel> mySodaList, string mySodaName) 
        {
            int indexToBeReturned = -1;
            for (int myIndex = 0; myIndex < mySodaList.Count; myIndex++) 
            {
                if (mySodaList.ElementAtOrDefault(myIndex).Name == mySodaName) 
                {
                    indexToBeReturned = myIndex;
                    break;
                }
            }
            return indexToBeReturned;
        }

    }
}