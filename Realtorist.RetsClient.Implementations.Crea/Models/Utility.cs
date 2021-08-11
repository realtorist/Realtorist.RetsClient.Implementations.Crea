using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Utility")]
    public class Utility
    {
        /// <summary>
        /// Type of utility available
        /// </summary>
        [XmlElement()]
        public XmlLookup<UtilityType> Type { get; set; }

        /// <summary>
        /// Description of utility available
        /// </summary>
        [XmlElement()]
        public string Description { get; set; }
    }
}