using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.RetsModels
{
    [XmlRoot(ElementName = "RETS")]
    public class RetsReply<T>
    {
        [XmlAttribute]
        public string ReplyText { get; set; }

        [XmlAttribute]
        public int ReplyCode { get; set; }

        [XmlElement(ElementName = "COUNT")]
        public Count Count { get; set; }

        [XmlElement(ElementName = "RETS-RESPONSE")]
        public T Response { get; set; }
    }
}
