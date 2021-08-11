using Realtorist.RetsClient.Implementations.Crea.Models;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.RetsModels
{
    [XmlRoot("RETS-RESPONSE")]
    public class MasterListResponse
    {
        [XmlElement("Pagination")]
        public Pagination Pagination { get; set; }

        [XmlElement("Property")]
        public Property[] Properties { get; set; }
    }
}
