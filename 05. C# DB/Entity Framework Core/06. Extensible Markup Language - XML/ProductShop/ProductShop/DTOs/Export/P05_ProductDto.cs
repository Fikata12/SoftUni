using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Product")]
    public class P05_ProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer", IsNullable = false)]
        public string? Buyer { get; set; }
    }
}