namespace Shopers.Models.Product
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
