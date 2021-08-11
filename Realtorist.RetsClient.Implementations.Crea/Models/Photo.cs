using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Photo")]
    public class Photo
    {
        /// <summary>
        /// Details of a single property photo
        /// </summary>
        [XmlElement()]
        public PropertyPhoto[] PropertyPhoto { get; set; }

        /// <summary>
        /// The date the photo was last updated
        /// </summary>
        [XmlElement()]
        public XmlDateTime LastUpdated { get; set; }

        /// <summary>
        /// Includes Url of the Thumbnail image
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string ThumbnailURL { get; set; }

        /// <summary>
        /// Includes Url of the High resolution image
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string LargePhotoURL { get; set; }
    }
}