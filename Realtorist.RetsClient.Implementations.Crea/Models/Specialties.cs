using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Specialties")]
    public class Specialties
    {
        /// <summary>
        /// The specialty of the Agent
        /// </summary>
        [XmlElement()]
        public string[] Specialty { get; set; }
    }
}