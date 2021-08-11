using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "AlternateURL")]
    public class AlternateURL
    {
        /// <summary>
        /// Link to brochure web site or document
        /// </summary>
        [XmlElement()]
        public string BrochureLink { get; set; }

        /// <summary>
        /// Link to a mapping site displaying the property location
        /// </summary>
        [XmlElement()]
        public string MapLink { get; set; }

        /// <summary>
        /// Link to a site containing additional photos
        /// </summary>
        [XmlElement()]
        public string PhotoLink { get; set; }

        /// <summary>
        /// Link to a site containing sound clips
        /// </summary>
        [XmlElement()]
        public string SoundLink { get; set; }

        /// <summary>
        /// Link to a site containing video for the property
        /// </summary>
        [XmlElement()]
        public string VideoLink { get; set; }
    }
}