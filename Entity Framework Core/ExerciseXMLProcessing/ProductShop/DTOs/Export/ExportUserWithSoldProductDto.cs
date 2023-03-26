//namespace ProductShop.DTOs.Export
//{
//    using System.Xml.Serialization;

//    [XmlType("User")]
//    public class ExportUserWithSoldProductDto
//    {
//        [XmlElement("firstName")]
//        public string FirstName { get; set; } = null!;

//        [XmlElement("lastName")]
//        public string LastName { get; set; } = null!;

//        [XmlElement("soldProducts")]
//        public virtual ExportSoldProductDto[] ProductsSold { get; set; } = null!;
//    }
//}

using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;


[XmlType("User")]
public class ExportSoldProductsDto
{
    [XmlElement("firstName")]
    public string FirstName { get; set; } = null!;

    [XmlElement("lastName")]
    public string LastName { get; set; } = null!;

    [XmlArray("soldProducts")]
    public ProductDto[] Products { get; set; }


}

[XmlType("Product")]
public class ProductDto
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("price")]
    public decimal Price { get; set; }
}