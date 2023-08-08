using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geoportal.Models
{
    [Table("validation")]
    public class ValidationModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("id_number")]
        public string IDNumber { get; set; }

        [Required]
        [Column("plot_number")]
        public string PlotNumber { get; set; }

        // Add additional properties as needed
        [Column("title_deed")]
        public string TitleDeed { get; set; }

        [Column("searches")]
        public string Search { get; set; }
    }
}
