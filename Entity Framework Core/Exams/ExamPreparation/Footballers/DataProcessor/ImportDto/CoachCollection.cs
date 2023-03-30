namespace Footballers.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlRoot("Coaches")]
    public class CoachCollection
    {
        [XmlArray("Coaches")]
        [XmlArrayItem("Coach")]
        public CoachDto[] Coaches { get; set; }
    }
}