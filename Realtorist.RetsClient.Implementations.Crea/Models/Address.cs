using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Address")]
    public class Address
    {
        /// <summary>
        /// This field returns a formatted street address. It may contain a vertical bar (|) line delimiter if address contains multiple lines.
        /// It includes the following address fields if available: AdditionalStreetInfo,
        /// UnitNumber,
        /// StreetNumber, StreetDirectionPrefix, StreetName, StreetSuffix, StreetDirectionSuffix, BoxNumber,
        /// 
        /// If the above fields do not yield a valid street Address, the following fields will be included instead (if available)
        /// 
        /// AdditionalStreetInfo, UnitNumber, AddressLine1,
        /// AddressLine2
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string StreetAddress { get; set; }

        /// <summary>
        /// The first address line of the address
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// The second address line of the address
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// The building number in the address
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Directional indicator that precedes the street name
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string StreetDirectionPrefix { get; set; }

        /// <summary>
        /// Official name of the street in the address
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string StreetName { get; set; }

        /// <summary>
        /// The street type
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string StreetSuffix { get; set; }

        /// <summary>
        /// Directional indicator that follows a street name
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string StreetDirectionSuffix { get; set; }

        /// <summary>
        /// Apartment, suite or office number portion of a postal address
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string UnitNumber { get; set; }

        /// <summary>
        /// Post office box if applicable
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string BoxNumber { get; set; }

        /// <summary>
        /// City of the address
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string City { get; set; }

        /// <summary>
        /// Province of the address
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Province { get; set; }

        /// <summary>
        /// Postal code of the address
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string PostalCode { get; set; }

        /// <summary>
        /// Country of the address
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Country { get; set; }

        /// <summary>
        /// Additional information about the street
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string AdditionalStreetInfo { get; set; }

        /// <summary>
        /// Community name of the address
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string CommunityName { get; set; }

        /// <summary>
        /// Neighbourhood name of the address
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Neighbourhood { get; set; }

        /// <summary>
        /// Subdivision name of the address
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Subdivision { get; set; }

        /// <summary>
        /// Latitude coordinates
        /// </summary>
        [XmlElement()]
        public double? Latitude { get; set; }

        /// <summary>
        /// Longitude coordinates
        /// </summary>
        [XmlElement()]
        public double? Longitude { get; set; }
    }
}