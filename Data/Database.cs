using Examen_II_B95811.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen_II_B95811.Data
{
    public class Database
    {
        public IList<SodaModel> Sodas { get; set; } = new List<SodaModel>();

        public Database()
        {
            Sodas.Add(new SodaModel("CocaCola", 10, 500));
            Sodas.Add(new SodaModel("Pepsi", 8, 600));
            Sodas.Add(new SodaModel("Fanta", 10, 550));
            Sodas.Add(new SodaModel("Sprite", 15, 725));
        }
        public IList<SodaModel> GetSodas() 
        {
            return Sodas;
        }

        public SodaModel RemoveSodas(SodaModel NameOfSoda, int AmountOfCans) 
        {
            int index = Sodas.IndexOf(NameOfSoda);
            Sodas.ElementAtOrDefault(index).CansAvailable -= AmountOfCans;
            return NameOfSoda;
        }

        public SodaModel AddSodas(SodaModel NameOfSoda, int AmountOfCans)
        {
            int index = Sodas.IndexOf(NameOfSoda);
            Sodas.ElementAtOrDefault(index).CansAvailable += AmountOfCans;
            return NameOfSoda;
        }
    }
}
