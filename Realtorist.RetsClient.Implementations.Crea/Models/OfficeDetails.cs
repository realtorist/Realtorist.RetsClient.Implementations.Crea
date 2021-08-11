using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "OfficeDetails")]
    public class OfficeDetails
    {
        /// <summary>
        /// The name of the Office
        /// </summary>
        [XmlElement()]
        public string Name { get; set; }

        /// <summary>
        /// Unique ID assigned to the Office
        /// </summary>
        [XmlAttribute()]
        public int ID { get; set; }

        /// <summary>
        /// Helper for parsing <see cref="LastUpdated">LastUpdated</see>
        /// </summary>
        [XmlIgnore]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Date the information was last updated
        /// </summary>
        [XmlAttribute(AttributeName = "LastUpdated")]
        public string LastUpdatedString
        {
            get { return LastUpdated.ToString(XmlDateTime.ExpectedGmtFormat); }
            set { LastUpdated = DateTime.Parse(value); }
        }

        /// <summary>
        /// Details of an Office’s photo
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Logo Logo { get; set; }

        /// <summary>
        /// The type of organization
        /// </summary>
        [XmlElement()]
        public string OrganizationType { get; set; }

        /// <summary>
        /// The designation of the organization
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Designation { get; set; }

        /// <summary>
        /// Address of the office
        /// </summary>
        [XmlElement()]
        public Address Address { get; set; }

        /// <summary>
        /// Collection of Phone
        /// </summary>
        [XmlElement()]
        public Phones Phones { get; set; }

        /// <summary>
        /// Collection of Website
        /// </summary>
        [XmlElement()]
        public Websites Websites { get; set; }

        /// <summary>
        /// The name of the franchisor
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Franchisor { get; set; }
    }
}