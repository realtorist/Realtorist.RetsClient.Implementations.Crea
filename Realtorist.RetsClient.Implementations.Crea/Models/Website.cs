using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Website")]
    public class Website
    {
        /// <summary>
        /// The type of contact (Business, Office, etc.)
        /// </summary>
        [XmlAttribute()]
        public string ContactType { get; set; }

        /// <summary>
        /// The type of the website
        /// </summary>
        [XmlAttribute()]
        public string WebsiteType { get; set; }

        /// <summary>
        /// Website url
        /// </summary>
        [XmlText()]
        public string Text { get; set; }
    }
}