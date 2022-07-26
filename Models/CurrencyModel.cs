namespace Examen_II_B95811.Models
{
    public class CurrencyModel
    {
        public string CurrencySymbol { get; set; }
        public double Value { get; set; }
        public int CashQuantity { get; set; }

        public CurrencyModel()
        {
            this.CurrencySymbol = String.Empty;
            this.Value = 0;
            this.CashQuantity = 0;
        }

        public CurrencyModel(string symbol, double value, int cash)
        {
            this.CurrencySymbol = symbol;
            this.Value = value;
            this.CashQuantity = cash;
        }
    }
}