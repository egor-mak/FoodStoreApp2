using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodStoreApp2.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DisplayName("Название")]
        public string? Name { get; set; }
        [DisplayName("Цена")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля")]
        public string? Country { get; set; }
    }
}
