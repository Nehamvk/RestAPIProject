using System.ComponentModel.DataAnnotations;

namespace RestAPIProject.DTOs
{
    public class UpdateProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100000)]
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
