using Microsoft.OData.Edm;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TestODataProject
{
    [Table("mas")]
    [ODataAnnotation(ODataMetadataTerm.DataCategory, NamesCollection.Data)]
    public class Mas
    {
        [IgnoreDataMember]
        [Column(nameof(product))]
        public int? ProductId { get; set; }

        [ODataAnnotation(ODataMetadataTerm.GroupableOffspringPaths, PathsCollection.RowIdAndName)]
        [ODataAnnotation(ODataMetadataTerm.ComparableOffspringPaths, PathsCollection.RowIdAndName)]
        public ChemicalMasPricesProduct? product { get; set; }

        [ODataAnnotation(ODataMetadataTerm.PropertyKind, NamesCollection.KindTechnical)]
        public string? document_id { get; set; }

        [Key]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string source_id { get; set; }

        [ODataAnnotation(ODataMetadataTerm.PropertyKind, NamesCollection.KindTechnical)]
        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public int? source_id_hash { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        [ODataAnnotation(ODataMetadataTerm.PropertyKind, NamesCollection.KindTechnical)]
        public DateTime? document_timestamp { get; set; }

        [ODataAnnotation(ODataMetadataTerm.PropertyKind, NamesCollection.KindTechnical)]
        public string[] collection_memberships { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        public string[]? subscription { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public DateOnly? historical_edge_date { get; set; }

        [ODataAnnotation(ODataMetadataTerm.PropertyKind, NamesCollection.KindTechnical)]
        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public DateOnly? last_update_date { get; set; }

        [ODataAnnotation(ODataMetadataTerm.WildcardAllowed)]
        public string? mnemonic { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? short_label { get; set; }

        [ODataAnnotation(ODataMetadataTerm.PropertyKind, NamesCollection.KindTechnical)]
        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? band_permissions { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public DateOnly? start_date { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public DateOnly? end_date { get; set; }

        public DateOnly? start_date_ch { get; set; }

        public DateOnly? end_date_ch { get; set; }

        [ODataAnnotation(ODataMetadataTerm.PropertyKind, NamesCollection.KindTechnical)]
        public string[]? tags { get; set; }

        public bool? include_in_cube { get; set; }

        public int? system_id { get; set; }

        public int? old_price_header_id { get; set; }

        public int? price_status_holder_id { get; set; }

        public bool? allow_zeroes { get; set; }

        public string? ca_terms { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        [ODataAnnotation(ODataMetadataTerm.PropertyKind, NamesCollection.KindTechnical)]
        public DateTime? last_update { get; set; }

        public bool? use_on_mobile { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? long_label { get; set; }

        public string? compat_timeseriesid { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public int? compat_castleid { get; set; }

        public string? compat_description { get; set; }

        public string[]? compat_connect_geographic_location_id { get; set; }

        public string[]? compat_othermetadata { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        public string[]? compat_localtimeseriesattribute { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        public string? compat_chemicalproduct { get; set; }

        public string? compat_connect_product_name { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? compat_connect_product_path { get; set; }

        public string? compat_connect_economic_concept_name { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? compat_connect_economic_concept_path { get; set; }

        public string? compat_connect_geographic_location_name { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? compat_connect_geography_path { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? compat_connect_local_timeseries_maspricesproduct { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? compat_connect_local_timeseries_maspricesgrade { get; set; }

        public string? compat_connect_local_timeseries_maspricesgradename { get; set; }

        public string? compat_connect_local_timeseries_maspricescategory { get; set; }

        public string? compat_connect_local_timeseries_maspricesgraphindicator { get; set; }

        public string? compat_connect_local_timeseries_maspricespricedescription { get; set; }

        public string? compat_connect_local_timeseries_maspricesstatus { get; set; }

        public string? compat_connect_local_timeseries_maspricestype { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? compat_connect_local_timeseries_maspricesterms { get; set; }

        public string? compat_connect_local_timeseries_maspricestermsname { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? compat_connect_local_timeseries_maspricessourcesystemregion { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? compat_connect_local_timeseries_maspricescurrencyperunit { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? compat_connect_local_timeseries_maspricescurrencyperunitname { get; set; }

        public string? compat_connect_local_timeseries_bandpermissions { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? compat_connect_local_timeseries_maspricesconcept { get; set; }

        public string? compat_connect_local_timeseries_maspricesshortlabel { get; set; }

        public string? compat_connect_local_timeseries_maspriceslastupdatedate { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public int? compat_connect_local_timeseries_maspricesproductgrade { get; set; }

        public string? compat_connect_local_timeseries_useonmobile { get; set; }

        public string[]? compat_connect_appsearchablemetadata { get; set; }

        public string? compat_document_type { get; set; }
    }
}
