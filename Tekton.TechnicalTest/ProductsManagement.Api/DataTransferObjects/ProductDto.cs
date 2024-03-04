namespace ProductsManagement.Api.DataTransferObjects
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string StatusName { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public byte Discount { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
