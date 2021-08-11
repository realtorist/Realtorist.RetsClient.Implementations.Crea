using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "PropertyPhoto")]
    public class PropertyPhoto
    {
        /// <summary>
        /// ID of the property photo. Required for GetObject calls
        /// </summary>
        [XmlElement()]
        public int SequenceID { get; set; }

        /// <summary>
        /// Description of the photo
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Description { get; set; }

        /// <summary>
        /// The timestamp, not including time zone, of when the photo was last updated
        /// </summary>
        [XmlElement()]
        public XmlDateTime LastUpdated { get; set; }

        /// <summary>
        /// The timestamp, including time zone, of when the photo was last updated. Example: Tue, 20 Oct 2015 09:23:13 GMT
        /// </summary>
        [XmlElement()]
        public XmlDateTime PhotoLastUpdated { get; set; }

        /// <summary>
        /// Includes Url of the Thumbnail image
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string ThumbnailURL { get; set; }

        /// <summary>
        /// Includes Url of the Medium resolution image
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string PhotoURL { get; set; }

        /// <summary>
        /// Includes Url of the High resolution image
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string LargePhotoURL { get; set; }
    }
}