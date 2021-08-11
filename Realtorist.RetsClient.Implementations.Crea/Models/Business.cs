using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Business")]
    public class Business
    {
        /// <summary>
        /// Type of Business
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<BusinessType> BusinessType { get; set; }

        /// <summary>
        /// Business Sub Type
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<BusinessSubType> BusinessSubType { get; set; }

        /// <summary>
        /// Date the Business was established
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string EstablishedDate { get; set; }

        /// <summary>
        /// Indicates whether business is a franchise or not
        /// </summary>
        [XmlElement()]
        public XmlBoolean Franchise { get; set; }

        /// <summary>
        /// Business Name
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Name { get; set; }

        /// <summary>
        /// Date indicating how long the business has been opened
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string OperatingSince { get; set; }
    }
}