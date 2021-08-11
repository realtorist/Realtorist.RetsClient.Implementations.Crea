using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Languages")]
    public class Languages
    {
        /// <summary>
        /// Language spoken of the Agent
        /// </summary>
        [XmlElement()]
        public string[] Language { get; set; }
    }
}