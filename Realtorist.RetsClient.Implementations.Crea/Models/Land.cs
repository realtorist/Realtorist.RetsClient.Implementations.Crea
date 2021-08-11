using Realtorist.Models.Enums.LookupTypes;
using Realtorist.Models.Xml;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Realtorist.RetsClient.Implementations.Crea.Models
{
    [XmlRoot(ElementName = "Land")]
    public class Land
    {
        /// <summary>
        /// The total size of the property
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement SizeTotal { get; set; }

        /// <summary>
        /// The total size of the property as text
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string SizeTotalText { get; set; }

        /// <summary>
        /// The amount of frontage of the property
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement SizeFrontage { get; set; }

        /// <summary>
        /// The type of access to the property
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<AccessType> AccessType { get; set; }

        /// <summary>
        /// Whether the property has acreage or not
        /// </summary>
        [XmlElement()]
        public XmlBoolean Acreage { get; set; }

        /// <summary>
        /// The land amenities
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<AmenitiesNearby> Amenities { get; set; }

        /// <summary>
        /// The amount of cleared land
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement ClearedTotal { get; set; }

        /// <summary>
        /// What the land is currently used for
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<CurrentUse> CurrentUse { get; set; }

        /// <summary>
        /// Whether the land is divisible or not (True/False)
        /// </summary>
        [XmlElement()]
        public XmlBoolean Divisible { get; set; }

        /// <summary>
        /// The amount of fencing
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement FenceTotal { get; set; }

        /// <summary>
        /// The type of fence
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<FenceType> FenceType { get; set; }

        /// <summary>
        /// The front type
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<FrontsOn> FrontsOn { get; set; }

        /// <summary>
        /// List of disposition features of the land
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<LandDispositionType> LandDisposition { get; set; }

        /// <summary>
        /// List of landscape features of the land
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<LandscapeFeatures> LandscapeFeatures { get; set; }

        /// <summary>
        /// The amount of pasture available
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement PastureTotal { get; set; }

        /// <summary>
        /// List of sewer types on the land
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<Sewer> Sewer { get; set; }

        /// <summary>
        /// The depth of the land
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement SizeDepth { get; set; }

        /// <summary>
        /// The size of irregular land
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public string SizeIrregular { get; set; }

        /// <summary>
        /// The soil evaluation
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public XmlLookup<SoilEvaluationType> SoilEvaluation { get; set; }

        /// <summary>
        /// The type of soil
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<SoilType> SoilType { get; set; }

        /// <summary>
        /// List of surface water types on the land
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<SurfaceWater> SurfaceWater { get; set; }

        /// <summary>
        /// The size of tiled land
        /// </summary>
        [MaybeNull]
        [XmlElement()]
        public Measurement TiledTotal { get; set; }

        /// <summary>
        /// Land topography type
        /// </summary>
        [XmlElement()]
        public XmlLookupCsvArray<TopographyType> TopographyType { get; set; }
    }
}