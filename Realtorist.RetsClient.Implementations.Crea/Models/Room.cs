using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Room")]
    public class Room
    {
        /// <summary>
        /// Type of room
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<RoomType> Type { get; set; }

        /// <summary>
        /// Width of the room
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement Width { get; set; }

        /// <summary>
        /// The level of the room
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<RoomLevel> Level { get; set; }

        /// <summary>
        /// The length of the room
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement Length { get; set; }

        /// <summary>
        /// General description of the room
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Description { get; set; }

        /// <summary>
        /// The dimensions of the room
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Dimension { get; set; }
    }
}