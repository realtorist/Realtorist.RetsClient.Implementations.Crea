using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.RetsModels
{
    public class Count
    {
        [XmlAttribute("Records")]
        public int Records { get; set; }
    }
}
