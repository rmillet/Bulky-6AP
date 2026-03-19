using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky_Web.Models
{
    public class Category
    {

        //Primary key van het model
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Verplicht")]
        [MaxLength(40,ErrorMessage ="Maximum 30 karakters!!!!")]
        [DisplayName("Categorienaam")]
        public string Name { get; set; } //Dit veld mag niet leeg zijn in de DATABASE + verplicht ook in te vullen in de UI

        [DisplayName("Categorievolgorde")]
        [Range(1,100,ErrorMessage ="Volgorde moet liggen tussen 1  en 100")]
        public int? DisplayOrder { get; set; }    //? --> Dit veld mag leeg zijn in de DATABASE
    }
}
