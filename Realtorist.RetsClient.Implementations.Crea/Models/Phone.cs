using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Phone")]
    public class Phone
    {
        /// <summary>
        /// The type of contact, e.g. Business
        /// </summary>
        [XmlAttribute()]
        public string ContactType { get; set; }

        /// <summary>
        /// The Type of phone line (Toll free, Fax, etc.)
        /// </summary>
        [XmlAttribute()]
        public string PhoneType { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [XmlText()]
        public string Text { get; set; }
    }
}