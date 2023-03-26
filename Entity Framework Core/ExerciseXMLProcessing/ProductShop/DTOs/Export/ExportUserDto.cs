namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;
    
    public class ExportUserDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUser[] Users { get; set; }
    }
}