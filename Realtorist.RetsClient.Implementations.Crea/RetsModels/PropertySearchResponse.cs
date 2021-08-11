using System.Xml.Serialization;
using Realtorist.RetsClient.Implementations.Crea.Models;

namespace Realtorist.RetsClient.Implementations.Crea.RetsModels
{
    [XmlRoot("RETS-RESPONSE")]
    public class PropertySearchResponse
    {
        [XmlElement("Pagination")]
        public Pagination Pagination { get; set; }

        [XmlElement("PropertyDetails")]
        public PropertyDetails[] Properties { get; set; }
    }
}
