using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Parking")]
    public class Parking
    {
        /// <summary>
        /// Type of parking available
        /// </summary>
        [XmlElement()]
        public XmlLookup<ParkingType> Name { get; set; }

        /// <summary>
        /// Number of spaces for the associated parking type
        /// </summary>
        [XmlElement()]
        public int? Spaces { get; set; }
    }
}