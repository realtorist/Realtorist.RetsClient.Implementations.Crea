using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "LiveStream")]
    public class LiveStream
    {
        /// <summary>
        /// Details of a Live Stream Open House event
        /// </summary>
        [XmlElement()]
        public Event[] Event { get; set; }
    }
}