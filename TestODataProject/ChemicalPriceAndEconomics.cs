using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestODataProject
{
    [Table("chemicalpriceandeconomics")]
    [ODataAnnotation(ODataMetadataTerm.FrequencyNameProperty, NamesCollection.FrequencyName)]
    public class ChemicalPriceAndEconomics
    {
        [ODataAnnotation(ODataMetadataTerm.PropertyKind, NamesCollection.KindTechnical)]
        public string? document_id { get; set; }

        [Key]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string source_id { get; set; }

        [ODataAnnotation(ODataMetadataTerm.PropertyKind, NamesCollection.KindTechnical)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        public DateTime? document_timestamp { get; set; }

        public string? datagroup { get; set; }

        public string? geographic_location { get; set; }

        public string? product_row_id { get; set; }

        public string? product_name { get; set; }

        public string? product_source_code { get; set; }

        public string? grade_row_id { get; set; }

        public string? grade_name { get; set; }

        public string? category_row_id { get; set; }

        public string? category_name { get; set; }

        public string? type_row_id { get; set; }

        public string? type_name { get; set; }

        public string? terms_row_id { get; set; }

        public string? terms_name { get; set; }

        public string? source_system_region_row_id { get; set; }

        public string? source_system_region_name { get; set; }

        public string? currency_per_unit_row_id { get; set; }

        public string? currency_per_unit_name { get; set; }

        public string? concept_row_id { get; set; }

        public string? concept_name { get; set; }

        [ODataAnnotation(ODataMetadataTerm.WildcardAllowed)]
        public string? mnemonic { get; set; }

        public string? product_grade_row_id { get; set; }

        public string? product_grade_name { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? short_label { get; set; }

        public string? frequency_row_id { get; set; }

        public string? frequency_name { get; set; }

        public string? frequency_source_code { get; set; }

        public string? flags_string { get; set; }

        public List<string>? flags
        {
            get
            {
                return new List<string> { "text 1", "text 2" };
            }
            set
            {
                ;
            }
        }

        public DateOnly? last_update_date { get; set; }

        public DateTime? last_update { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public DateOnly? start_date { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Groupable)]
        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public DateOnly? end_date { get; set; }

        public int? old_price_header_id { get; set; }

        [ODataAnnotation(ODataMetadataTerm.Comparable)]
        public string? long_label { get; set; }

        public ICollection<ObservationMas>? observations { get; set; }
    }
}
