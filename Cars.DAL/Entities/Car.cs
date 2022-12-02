using System.ComponentModel.DataAnnotations;

namespace Cars.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
