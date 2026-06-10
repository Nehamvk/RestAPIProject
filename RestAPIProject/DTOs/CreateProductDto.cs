using System.ComponentModel.DataAnnotations;

namespace RestAPIProject.DTOs
{

    public class CreateProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100000)]
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
