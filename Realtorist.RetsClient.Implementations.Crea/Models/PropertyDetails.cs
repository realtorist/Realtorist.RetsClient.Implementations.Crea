using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "PropertyDetails")]
    public class PropertyDetails
    {
        /// <summary>
        /// Unique ID assigned to the property
        /// </summary>
        [XmlAttribute()]
        public int ID { get; set; }

        /// <summary>
        /// The MLS Number of the property.
        /// </summary>
        [XmlElement()]
        public string ListingID { get; set; }

        /// <summary>
        /// Helper for parsing <see cref="LastUpdated">LastUpdated</see>
        /// </summary>
        [XmlIgnore]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// The date the property was last updated
        /// </summary>
        [XmlAttribute(AttributeName = "LastUpdated")]
        public string LastUpdatedString
        {
            get { return LastUpdated.ToString(XmlDateTime.ExpectedGmtFormat); }
            set { LastUpdated = DateTime.Parse(value); }
        }

        /// <summary>
        /// Business details of property
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Business Business { get; set; }

        /// <summary>
        /// ID of the Board/Association responsible for
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<Boards> Board { get; set; }

        /// <summary>
        /// Building details of the property
        /// </summary>
        [XmlElement()]
        public Building Building { get; set; }

        /// <summary>
        /// Details about the land of the property
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Land Land { get; set; }

        /// <summary>
        /// Agent details
        /// </summary>
        [XmlElement()]
        public AgentDetails[] AgentDetails { get; set; }

        /// <summary>
        /// Address of property
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Address Address { get; set; }

        /// <summary>
        /// Set of links to information about the property
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public AlternateURL AlternateURL { get; set; }

        /// <summary>
        /// List of amenities nearby to the property
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<AmenitiesNearby> AmmenitiesNearBy { get; set; }

        /// <summary>
        /// The communication type available
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<CommunicationType> CommunicationType { get; set; }

        /// <summary>
        /// The community features
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<CommunityFeatures> CommunityFeatures { get; set; }

        /// <summary>
        /// The types of crops available
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<Crop> Crop { get; set; }

        /// <summary>
        /// Documents available
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<DocumentType> DocumentType { get; set; }

        /// <summary>
        /// List of equipment available
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<EquipmentType> EquipmentType { get; set; }

        /// <summary>
        /// The property easement types
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<Easement> Easement { get; set; }

        /// <summary>
        /// The type of farm
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<FarmType> FarmType { get; set; }

        /// <summary>
        /// The property features available
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<Features> Features { get; set; }

        /// <summary>
        /// The type of irrigation of the property
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<IrrigationType> IrrigationType { get; set; }

        /// <summary>
        /// Lease value
        /// </summary>
        [XmlElement()]
        public double? Lease { get; set; }

        /// <summary>
        /// Lease time e.g. quarterly
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<PaymentUnit> LeasePerTime { get; set; }

        /// <summary>
        /// Lease unit e.g. square feet
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<MeasureUnit> LeasePerUnit { get; set; }

        /// <summary>
        /// Duration of the lease remaining.
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string LeaseTermRemaining { get; set; }

        /// <summary>
        /// The frequency of the remaining lease e.g. daily
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<PaymentUnit> LeaseTermRemainingFreq { get; set; }

        /// <summary>
        /// Type of lease
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<LeaseType> LeaseType { get; set; }

        /// <summary>
        /// The effective date of the agreement between the seller and the seller’s broker
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string ListingContractDate { get; set; }

        /// <summary>
        /// The types of livestock available
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<LiveStockType> LiveStockType { get; set; }

        /// <summary>
        /// Property loading type available
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<LoadingType> LoadingType { get; set; }

        /// <summary>
        /// A description of the location
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string LocationDescription { get; set; }

        /// <summary>
        /// Machinery available
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<Machinery> Machinery { get; set; }

        /// <summary>
        /// Condo/Maintenances fees
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string MaintenanceFee { get; set; }

        /// <summary>
        /// Condo/Maintenances fee payment unit (Frequency)
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<PaymentUnit> MaintenanceFeePaymentUnit { get; set; }

        /// <summary>
        /// Condo/Maintenances fee type
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<MaintenanceFeeType> MaintenanceFeeType { get; set; }

        /// <summary>
        /// The name of management company
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string ManagementCompany { get; set; }

        /// <summary>
        /// The id of municipality
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string MunicipalID { get; set; }

        /// <summary>
        /// Collection of open house Events
        /// </summary>
        [XmlElement()]
        public OpenHouse OpenHouse { get; set; }

        /// <summary>
        /// Collection of Live Streame Open House events
        /// </summary>
        [XmlElement()]
        public LiveStream LiveStream { get; set; }

        /// <summary>
        /// The type of ownership ex: Condo/Strata, freehold etc.
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<OwnershipType> OwnershipType { get; set; }

        /// <summary>
        /// Collection of Parking. Available if parking type details are available
        /// </summary>
        [XmlElement()]
        public ParkingSpaces ParkingSpaces { get; set; }

        /// <summary>
        /// The total number of parking spaces
        /// </summary>
        [XmlElement()]
        public int? ParkingSpaceTotal { get; set; }

        /// <summary>
        /// Collection of PropertyPhoto
        /// </summary>
        [XmlElement()]
        public Photo Photo { get; set; }

        /// <summary>
        /// Plan of the property
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Plan { get; set; }

        /// <summary>
        /// The type of pool on the property
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<PoolType> PoolType { get; set; }

        /// <summary>
        /// The features of the pool
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<PoolFeatures> PoolFeatures { get; set; }

        /// <summary>
        /// Price of the Property
        /// </summary>
        [XmlElement()]
        public double? Price { get; set; }

        /// <summary>
        /// Price of property per time
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<PaymentUnit> PricePerTime { get; set; }

        /// <summary>
        /// Price of property per unit
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<MeasureUnit> PricePerUnit { get; set; }

        /// <summary>
        /// Type of real estate property
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<PropertyType> PropertyType { get; set; }

        /// <summary>
        /// Description of the property
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string PublicRemarks { get; set; }

        /// <summary>
        /// The type of rental equipment
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<RentalEquipmentType> RentalEquipmentType { get; set; }

        /// <summary>
        /// List of property rights
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<RightType> RightType { get; set; }

        /// <summary>
        /// Type of road
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<RoadType> RoadType { get; set; }

        /// <summary>
        /// Storage Type Included
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<StorageType> StorageType { get; set; }

        /// <summary>
        /// List of structures on the property
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<StructureType> Structure { get; set; }

        /// <summary>
        /// Type of signage
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<SignType> SignType { get; set; }

        /// <summary>
        /// Type of transaction (e.g. sale, lease)
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<TransactionType> TransactionType { get; set; }

        /// <summary>
        /// Total number of buildings included in the property
        /// </summary>
        [XmlElement()]
        public int? TotalBuildings { get; set; }

        /// <summary>
        /// Collection of Utility
        /// </summary>
        [XmlElement()]
        public UtilitiesAvailable UtilitiesAvailable { get; set; }

        /// <summary>
        /// Types of views available
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<ViewType> ViewType { get; set; }

        /// <summary>
        /// Waterfront type of the property
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<WaterFrontType> WaterFrontType { get; set; }

        /// <summary>
        /// Name of the waterfront the property is on
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string WaterFrontName { get; set; }

        /// <summary>
        /// Additional information indicator text
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string AdditionalInformationIndicator { get; set; }

        /// <summary>
        /// Description of the zoning
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string ZoningDescription { get; set; }

        /// <summary>
        /// Property Zoning type
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<ZoningType> ZoningType { get; set; }

        /// <summary>
        /// Link to the property details page on Realtor.ca
        /// </summary>
        [XmlElement()]
        public string MoreInformationLink { get; set; }

        /// <summary>
        /// Link to property specified by Agent/Realtor Member
        /// </summary>
        [XmlElement()]
        public string SocialMediaWebsite { get; set; }

        /// <summary>
        /// Used for statistical tracking of MoreInformationLink. (deprecated, included for backwards compatibility)
        /// </summary>
        [XmlElement()]
        public string AnalyticsClick { get; set; }

        /// <summary>
        /// Used for statistical tracking of property details views on DDF® client sites. (deprecated, included for backwards compatibility)
        /// </summary>
        [XmlElement()]
        public string AnalyticsView { get; set; }
    }
}