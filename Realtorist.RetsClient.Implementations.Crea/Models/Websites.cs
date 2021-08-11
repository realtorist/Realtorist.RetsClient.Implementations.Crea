using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Websites")]
    public class Websites
    {
        /// <summary>
        /// The website of the organization
        /// </summary>
        [XmlElement()]
        public Website[] Website { get; set; }
    }
}