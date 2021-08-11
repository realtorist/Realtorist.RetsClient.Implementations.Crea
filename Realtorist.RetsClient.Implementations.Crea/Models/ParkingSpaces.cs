using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "ParkingSpaces")]
    public class ParkingSpaces
    {
        /// <summary>
        /// Details of the parking type
        /// </summary>
        [XmlElement()]
        public Parking[] Parking { get; set; }
    }
}