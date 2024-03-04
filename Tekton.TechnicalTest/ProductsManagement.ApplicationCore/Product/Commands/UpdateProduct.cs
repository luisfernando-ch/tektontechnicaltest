using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductsManagement.ApplicationCore.Product.Commands
{
    public class UpdateProduct
    {
        [Key]
        [Required(ErrorMessage = "El ID del producto es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del producto debe ser mayor que 0.")]
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(256, ErrorMessage = "La longitud del nombre no puede exceder los 256 caracteres.")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0, 1, ErrorMessage = "El estado debe ser 0 o 1.")]
        public byte Status { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }

        [StringLength(1024, ErrorMessage = "La descripción no puede exceder los 1024 caracteres.")]
        public string Description { get; set; } = null!;

        [Column(TypeName = "money")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public byte Discount { get; set; }

    }
}
