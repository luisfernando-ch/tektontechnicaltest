using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsManagement.ApplicationCore.Entities;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(256)]
    public string Name { get; set; } = null!;

    public byte Status { get; set; }

    public int Stock { get; set; }

    [StringLength(1024)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    public byte Discount { get; set; }

    [Column(TypeName = "money")]
    public decimal FinalPrice { get; set; }
}
