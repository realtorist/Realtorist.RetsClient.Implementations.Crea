using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Agent")]
    public class Agent
    {
        /// <summary>
        /// Unique ID assigned to the Agent
        /// </summary>
        [XmlAttribute()]
        public int ID { get; set; }

        /// <summary>
        /// Helper for parsing <see cref="LastUpdated">LastUpdated</see>
        /// </summary>
        [XmlIgnore]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// The date agent information was last updated
        /// </summary>
        [XmlAttribute(AttributeName = "LastUpdated")]
        public string LastUpdatedString
        {
            get { return LastUpdated.ToString(XmlDateTime.ExpectedGmtFormat); }
            set { LastUpdated = DateTime.Parse(value); }
        }
    }
}