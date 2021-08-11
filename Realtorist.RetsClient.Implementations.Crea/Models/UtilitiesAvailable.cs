using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "UtilitiesAvailable")]
    public class UtilitiesAvailable
    {
        /// <summary>
        /// Details of a single utility
        /// </summary>
        [XmlElement()]
        public Utility[] Utility { get; set; }
    }
}