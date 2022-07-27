using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Examen_II_B95811.Models
{
    public class SodaModel
    {
        [Required(ErrorMessage = "Choose the name of the soda")]
        [DisplayName("Name of soda")]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Choose the amount of cans")]
        [DisplayName("Cans chosen")]
        public int CansAvailable { get; set; }
        public double PriceOfCan { get; set; }
        public string Currency { get; set; }
        public SodaModel()
        {
            this.Name = String.Empty;
            this.CansAvailable = 0;
            this.PriceOfCan = 0;
            this.Currency = "₡";
        }

        public SodaModel(string Name, int cans, double price, string currencySymbol)
        {
            this.Name = Name;
            this.CansAvailable = cans;
            this.PriceOfCan = price;
            this.Currency = currencySymbol;
        }
    }
}