using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "AgentDetails")]
    public class AgentDetails
    {
        /// <summary>
        /// The name of the Agent
        /// </summary>
        [XmlElement()]
        public string Name { get; set; }

        /// <summary>
        /// Unique ID assigned to the Agent
        /// </summary>
        [XmlAttribute()]
        public int ID { get; set; }

        /// <summary>
        /// The date the agent was last updated
        /// </summary>
        [XmlAttribute()]
        public string LastUpdated { get; set; }

        /// <summary>
        /// The position of the Agent
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Position { get; set; }

        /// <summary>
        /// Collection of Website
        /// </summary>
        [XmlElement()]
        public Websites Websites { get; set; }

        /// <summary>
        /// Collection of Phone
        /// </summary>
        [XmlElement()]
        public Phones Phones { get; set; }

        /// <summary>
        /// The organization that the Agent works for
        /// </summary>
        [XmlElement()]
        public OfficeDetails Office { get; set; }

        /// <summary>
        /// The credentials of the Agent
        /// </summary>
        [XmlElement()]
        public XmlStringCsvArray EducationCredentials { get; set; }

        /// <summary>
        /// Details of the Agent Photo
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Photo Photo { get; set; }

        /// <summary>
        /// Address of the office
        /// </summary>
        [XmlElement()]
        public Address Address { get; set; }

        /// <summary>
        /// The specialty of the Agent
        /// </summary>
        [XmlElement()]
        public Specialties Specialties { get; set; }

        /// <summary>
        /// Collection of Designation
        /// </summary>
        [XmlElement()]
        public Designations Designations { get; set; }

        /// <summary>
        /// Collection of Language
        /// </summary>
        [XmlElement()]
        public Languages Languages { get; set; }

        /// <summary>
        /// Collection of TradingArea
        /// </summary>
        [XmlElement()]
        public TradingAreas TradingAreas { get; set; }
    }
}