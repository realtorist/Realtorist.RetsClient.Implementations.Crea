using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Phones")]
    public class Phones
    {
        /// <summary>
        /// The phone number
        /// </summary>
        [XmlElement()]
        public Phone[] Phone { get; set; }
    }
}