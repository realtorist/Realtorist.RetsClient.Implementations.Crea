using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Building")]
    public class Building
    {
        /// <summary>
        /// Number of bathrooms
        /// </summary>
        [XmlElement()]
        public int? BathroomTotal { get; set; }

        /// <summary>
        /// Number of bedrooms above ground
        /// </summary>
        [XmlElement()]
        public int? BedroomsAboveGround { get; set; }

        /// <summary>
        /// Number of bedrooms below ground
        /// </summary>
        [XmlElement()]
        public int? BedroomsBelowGround { get; set; }

        /// <summary>
        /// Number of bedrooms (below + above ground)
        /// </summary>
        [XmlElement()]
        public int? BedroomsTotal { get; set; }

        /// <summary>
        /// The age of the building
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Age { get; set; }

        /// <summary>
        /// The building amenities
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<Amenities> Amenities { get; set; }

        /// <summary>
        /// The building amperage
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<Amperage> Amperage { get; set; }

        /// <summary>
        /// The building anchor
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Anchor { get; set; }

        /// <summary>
        /// The appliances included with the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<Appliances> Appliances { get; set; }

        /// <summary>
        /// Architectural style of the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<ArchitecturalStyle> ArchitecturalStyle { get; set; }

        /// <summary>
        /// Development of the basement
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<BasementDevelopment> BasementDevelopment { get; set; }

        /// <summary>
        /// Features of the basement
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<BasementFeatures> BasementFeatures { get; set; }

        /// <summary>
        /// The type of basement
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<BasementType> BasementType { get; set; }

        /// <summary>
        /// BOMA energy performance rating
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string BomaRating { get; set; }

        /// <summary>
        /// Ceiling height of the building
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement CeilingHeight { get; set; }

        /// <summary>
        /// Ceiling type of the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<CeilingType> CeilingType { get; set; }

        /// <summary>
        /// Clear ceiling height of the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<ClearCeilingHeight> ClearCeilingHeight { get; set; }

        /// <summary>
        /// The year the building was built
        /// </summary>
        [XmlElement()]
        public int? ConstructedDate { get; set; }

        /// <summary>
        /// List of construction materials used in the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<ConstructionMaterial> ConstructionMaterial { get; set; }

        /// <summary>
        /// The status of the building
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<ConstructionStatus> ConstructionStatus { get; set; }

        /// <summary>
        /// The attachment style of the building
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<ConstructionStyleAttachment> ConstructionStyleAttachment { get; set; }

        /// <summary>
        /// Construction style other
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<ConstructionStyleOther> ConstructionStyleOther { get; set; }

        /// <summary>
        /// Construction style split level
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<ConstructionStyleSplitLevel> ConstructionStyleSplitLevel { get; set; }

        /// <summary>
        /// Type of Cooling in the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<CoolingType> CoolingType { get; set; }

        /// <summary>
        /// Energuide energy performance rating
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string EnerguideRating { get; set; }

        /// <summary>
        /// The exterior finish of the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<ExteriorFinish> ExteriorFinish { get; set; }

        /// <summary>
        /// Fire protection and security features of building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<FireProtection> FireProtection { get; set; }

        /// <summary>
        /// List of fireplace fuels for the fireplaces in building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<FireplaceFuel> FireplaceFuel { get; set; }

        /// <summary>
        /// Indicates whether there is a fireplace in building
        /// </summary>
        [XmlElement()]
        public XmlBoolean FireplacePresent { get; set; }

        /// <summary>
        /// Total number of fireplaces present in building
        /// </summary>
        [XmlElement()]
        public int? FireplaceTotal { get; set; }

        /// <summary>
        /// The types of fireplace in the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<FireplaceType> FireplaceType { get; set; }

        /// <summary>
        /// Building fixture
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<Fixture> Fixture { get; set; }

        /// <summary>
        /// The type of flooring in the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<FlooringType> FlooringType { get; set; }

        /// <summary>
        /// The type of foundation of the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<FoundationType> FoundationType { get; set; }

        /// <summary>
        /// The number of half Bathrooms
        /// </summary>
        [XmlElement()]
        public int? HalfBathTotal { get; set; }

        /// <summary>
        /// Fuel used for heating the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<HeatingFuel> HeatingFuel { get; set; }

        /// <summary>
        /// The heating type of the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<HeatingType> HeatingType { get; set; }

        /// <summary>
        /// LEEDS green building certification category
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string LeedsCategory { get; set; }

        /// <summary>
        /// LEEDS green building certification rating
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string LeedsRating { get; set; }

        /// <summary>
        /// The date the building was renovated
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string RenovatedDate { get; set; }

        /// <summary>
        /// The type of roofing material of the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<RoofMaterial> RoofMaterial { get; set; }

        /// <summary>
        /// The roof style of the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<RoofStyle> RoofStyle { get; set; }

        /// <summary>
        /// Collection of Room
        /// </summary>
        [XmlElement()]
        public Rooms Rooms { get; set; }

        /// <summary>
        /// The number of stories of the building
        /// </summary>
        [XmlElement()]
        public double? StoriesTotal { get; set; }

        /// <summary>
        /// Building interior size
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement SizeExterior { get; set; }

        /// <summary>
        /// Building exterior size
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement SizeInterior { get; set; }

        /// <summary>
        /// The size of finished interior
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement SizeInteriorFinished { get; set; }

        /// <summary>
        /// The building storefront
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<StoreFront> StoreFront { get; set; }

        /// <summary>
        /// Total finished area
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement TotalFinishedArea { get; set; }

        /// <summary>
        /// Type of Building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<BuildingType> Type { get; set; }

        /// <summary>
        /// UFFI (Urea Formaldehyde Foam Insulation) status
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string Uffi { get; set; }

        /// <summary>
        /// Type of unit
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string UnitType { get; set; }

        /// <summary>
        /// The types of power in the building
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<UtilityPower> UtilityPower { get; set; }

        /// <summary>
        /// Building water type
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<UtilityWater> UtilityWater { get; set; }

        /// <summary>
        /// The rate of vacancy
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string VacancyRate { get; set; }
    }
}