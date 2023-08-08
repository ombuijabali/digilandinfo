using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geoportal.Models
{
    public class SurveyModel
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("id_number")]
        public string ID_Number { get; set; }

        [Column("first_name")]
        public string First_Name { get; set; }

        [Column("last_name")]
        public string Last_Name { get; set; }

        [Column("plot_no")]
        public string Plot_No { get; set; }

        [Column("plot_size")]
        public string Plot_Size { get; set; }

        [Column("sheet_no")]
        public string Sheet_No { get; set; }

        [Column("block_no")]
        public string Block_No { get; set; }

        [Column("x_coordinate")]
        public string X_Coordinate { get; set; }

        [Column("y_coordinate")]
        public string Y_Coordinate { get; set; }

        [NotMapped]
        public string[] X_Coordinates { get; set; }

        [NotMapped]
        public string[] Y_Coordinates { get; set; }
    }
}
