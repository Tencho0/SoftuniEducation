namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class ExportSoldProductsForUserDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("soldProducts")]
        public ExportSoldProductDto[] Products { get; set; }
    }
}