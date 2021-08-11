using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Designations")]
    public class Designations
    {
        /// <summary>
        /// The designation of the Agent
        /// </summary>
        [XmlElement()]
        public string[] Designation { get; set; }
    }
}