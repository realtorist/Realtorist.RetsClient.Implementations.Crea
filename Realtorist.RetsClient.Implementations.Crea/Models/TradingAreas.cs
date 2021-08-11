using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "TradingAreas")]
    public class TradingAreas
    {
        /// <summary>
        /// Trading area of the agent
        /// </summary>
        [XmlElement()]
        public string[] TradingArea { get; set; }
    }
}