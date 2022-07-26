namespace Examen_II_B95811.Models
{
    public class SodaModel
    {
        public string Name { get; set; }

        public int CansAvailable { get; set; }
        public double PriceOfCan { get; set; }
        public SodaModel()
        {
            this.Name = String.Empty;
            this.CansAvailable = 0;
            this.PriceOfCan = 0;
        }

        public SodaModel(string Name, int cans, double price)
        {
            this.Name = Name;
            this.CansAvailable = cans;
            this.PriceOfCan = price;
        }
    }
}