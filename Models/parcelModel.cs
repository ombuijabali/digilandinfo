using System.ComponentModel.DataAnnotations.Schema;

namespace Geoportal.Models
{
    [Table("parcels")]
    public class ParcelModel
    {
        [Column("id_number")]
        public int ID_Number { get; set; }

        [Column("first_name")]
        public string First_Name { get; set; }

        [Column("last_name")]
        public string Last_Name { get; set; }

        [Column("plot_no")]
        public string Plot_No { get; set; }

        [Column("plot_size")]
        public decimal Plot_Size { get; set; }

        [Column("land_value")]
        public decimal? Land_Value { get; set; }

        [Column("rate")]
        public decimal? Rate { get; set; }

        [Column("sheet_no")]
        public int? Sheet_No { get; set; }

        [Column("block_no")]
        public int? Block_No { get; set; }

        [Column("landuse")]
        public string LandUse { get; set; }
    }
}
