using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "OpenHouse")]
    public class OpenHouse
    {
        /// <summary>
        /// Details of a single open house event
        /// </summary>
        [XmlElement()]
        public Event[] Event { get; set; }
    }
}