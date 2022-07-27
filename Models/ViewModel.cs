using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Examen_II_B95811.Models
{
    public class ViewModel
    {
        public List<SodaModel> SodaList { get; set; }
        public SodaModel ASoda { get; set; }
    }
}