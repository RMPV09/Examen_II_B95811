using Examen_II_B95811.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen_II_B95811.Data
{
    public class Database
    {
        public IList<SodaModel> Sodas { get; set; } = new List<SodaModel>();

        public IList<SodaModel> SetDatabase()
        {
            Sodas.Add(new SodaModel("CocaCola", 10, 500, "₡"));
            Sodas.Add(new SodaModel("Pepsi", 8, 600, "₡"));
            Sodas.Add(new SodaModel("Fanta", 10, 550, "₡"));
            Sodas.Add(new SodaModel("Sprite", 15, 725, "₡"));
            return Sodas;
        }

        public IList<SodaModel> GetSodas() 
        {
            return Sodas;
        }

        public IList<SodaModel> RemoveSodas(int amountOfCans, int index) 
        {
            Sodas.ElementAt(index).CansAvailable -= amountOfCans;
            return Sodas;
        }

        public SodaModel AddSodas(SodaModel nameOfSoda, int amountOfCans)
        {
            nameOfSoda.CansAvailable += amountOfCans;
            return nameOfSoda;
        }

        public int GetIndexBySoda(string nameOfSoda)
        {
            int index = -1;
            for (int myIndex = 0; myIndex < Sodas.Count(); myIndex++) 
            {
                if (Sodas.ElementAt(myIndex).Name == nameOfSoda) 
                {
                    index = myIndex;
                    break;
                }
            }
            return index;
        }
    }
}
