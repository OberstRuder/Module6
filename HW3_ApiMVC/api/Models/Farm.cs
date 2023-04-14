using System.ComponentModel.DataAnnotations;

namespace HW1.Models
{
    public class Farm
    {
        [Required(AllowEmptyStrings = false)]
        public int Id { get; set; }

        [Required]
        public string KindOfAnimal { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Weight { get; set; }
    }
}
