using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geoportal.Models
{
    [Table("documents")]
    public class DocumentsModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("serial_number")]
        public string SerialNumber { get; set; }

        [Column("document_content")]
        public byte[] DocumentContent { get; set; }
    }
}
