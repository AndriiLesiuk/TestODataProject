using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TestODataProject
{
    [Table("chemicalmaspricesproduct")]
    public class ChemicalMasPricesProduct
    {
        [Key]
        public int row_id { get; set; }

        public string? document_id { get; set; }

        public string? name { get; set; }

        public string? display_name { get; set; }

        public string? unique_name { get; set; }

        public string? source_code { get; set; }

        public DateTime? document_timestamp { get; set; }

        [IgnoreDataMember]
        public ICollection<Mas>? Mas { get; set; }
    }
}
