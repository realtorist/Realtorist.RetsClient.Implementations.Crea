using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Event")]
    public class Event
    {
        /// <summary>
        /// The open house start date and time
        /// </summary>
        [XmlElement()]
        public XmlDateTime StartDateTime { get; set; }

        /// <summary>
        /// The open house End date and time
        /// </summary>
        [XmlElement()]
        public XmlDateTime EndDateTime { get; set; }

        /// <summary>
        /// Comments about the open house
        /// </summary>
        [XmlElement()]
        public string Comments { get; set; }

        /// <summary>
        /// URL to the Live Stream
        /// </summary>
        [XmlElement()]
        public string URL { get; set; }
    }
}