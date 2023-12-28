using System.Reflection;

namespace TestODataProject
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public class ODataAnnotationAttribute : Attribute
    {
        public ODataMetadataTerm Term { get; }
        public string[] Collection { get; }
        public ODataAnnotationAttribute(ODataMetadataTerm term, string collection = "")
        {
            Term = term;
            Collection = collection.Split(',');
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class AnnotationDescriptionAttribute : Attribute
    {
        public string NameSpace { get; }
        public string Name { get; set; }
        public ODataAnnotationType AnnotationType { get; }
        public AnnotationDescriptionAttribute(string nameSpace, string name, ODataAnnotationType annotationType)
        {
            NameSpace = nameSpace;
            Name = name;
            AnnotationType = annotationType;
        }
    }

    public enum ODataAnnotationType
    {
        Collection,
        String,
        Bool
    }

    public enum DataPlatformEnumMember
    {
        None
    }

    public enum ODataMetadataTerm
    {
        [AnnotationDescription("Self", "PropertyKind", ODataAnnotationType.String)]
        PropertyKind,
        [AnnotationDescription("Self", "EntitySetCategory", ODataAnnotationType.String)]
        DataCategory,
        [AnnotationDescription("Self", "EntitySetCategory", ODataAnnotationType.String)]
        DictionaryCategory,
        [AnnotationDescription("Self", "BasicFields", ODataAnnotationType.Collection)]
        BasicFields,
        [AnnotationDescription("Self", "CustomPropertyOrder", ODataAnnotationType.String)]
        CustomPropertyOrder,
        [AnnotationDescription("Self", "Comparable", ODataAnnotationType.Bool)]
        Comparable,
        [AnnotationDescription("Self", "ComparableOffspringPaths", ODataAnnotationType.Collection)]
        ComparableOffspringPaths,
        [AnnotationDescription("Self", "Groupable", ODataAnnotationType.Bool)]
        Groupable,
        [AnnotationDescription("Self", "WildcardAllowed", ODataAnnotationType.Bool)]
        WildcardAllowed,
        [AnnotationDescription("Self", "GroupableOffsprintPaths", ODataAnnotationType.Collection)]
        GroupableOffspringPaths,
        [AnnotationDescription("Self", "FriendlyName", ODataAnnotationType.String)]
        FriendlyName,
        [AnnotationDescription("Self", "FrequencyNameProperty", ODataAnnotationType.String)]
        FrequencyNameProperty,
        [AnnotationDescription("Self", "DictionaryViewLabel", ODataAnnotationType.String)]
        DictionaryViewLabel,
    }

    public static class ODataAnnotationEnumHelper
    {
        public static AnnotationDescriptionAttribute GetEnumDescription(this ODataMetadataTerm enumValue) =>
            enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<AnnotationDescriptionAttribute>();
    }

    public static class PathsCollection
    {
        public const string RowIdAndName = "row_id,name";
        public const string Subscription = "subscription";
        public const string RowIdAndNameAndStandardTaxonomyPath = "row_id,name,standard_taxonomy/path";
        public const string RowIdAndNameAndStandardTaxonomyPathAndAncestorRowId = "row_id,name,standard_taxonomy/path,standard_taxonomy/ancestor/row_id";
    }

    public static class NamesCollection
    {
        public const string Dictionary = "Dictionary";
        public const string Data = "Data";
        public const string KindTechnical = "Technical";
        public const string CountryTerritory = "Country/Territory";
        public const string Frequency = "frequency";
        public const string FrequencyName = "frequency_name";
        public const string City = "City";
        public const string AssetId = "Asset ID";
        public const string Company = "Company";
        public const string SeriesId = "Series ID";
        public const string Region = "Region";
        public const string EquipmentNickname = "Equipment Nickname";
        public const string Comments = "Comments";
        public const string AssumptionFlag = "Assumption Flag";
        public const string State = "State";
        public const string Product = "Product";
        public const string Process = "Process";
        public const string FeedslateSource = "Feedslate Source";
        public const string Feed = "Feed";
        public const string ProductionSource = "Production Source";
        public const string Concept = "Concept";
        public const string OutageType = "Outage Type";
        public const string Observations = "Observations";
    }
}
