using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Rooms")]
    public class Rooms
    {
        /// <summary>
        /// Details of a single room
        /// </summary>
        [XmlElement()]
        public Room[] Room { get; set; }
    }
}