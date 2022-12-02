using System.ComponentModel.DataAnnotations;

namespace Cars.BLL.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
