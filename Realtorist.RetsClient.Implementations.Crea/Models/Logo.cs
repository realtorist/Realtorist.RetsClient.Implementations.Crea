using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Logo")]
    public class Logo
    {
        /// <summary>
        /// Includes Url of the Thumbnail image
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string ThumbnailURL { get; set; }

        /// <summary>
        /// The date the logo was last updated
        /// </summary>
        [XmlElement()]
        public XmlDateTime LogoLastUpdated { get; set; }
    }
}