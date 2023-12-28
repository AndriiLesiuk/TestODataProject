using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TestODataProject
{
    [Table("observations_mas")]
    public class ObservationMas
    {

        [Key]
        [IgnoreDataMember]
        public string source_id { get; set; }
        [Key]
        public DateOnly? date { get; set; }

        public decimal? value { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ChemicalPriceAndEconomics? ChemicalPriceAndEconomics { get; set; }
    }
}
