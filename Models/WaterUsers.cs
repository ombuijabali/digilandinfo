using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geoportal.Models
{
    [Table("waterusers")] // Specify the table name
    public class WaterUser
    {
        [Key]
        [Column("id_number")]
        public int ID_Number { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("first_name")] // Specify the column name
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("last_name")] // Specify the column name
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("plot_no")] // Specify the column name
        public string PlotNo { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("meter_no")] // Specify the column name
        public string MeterNo { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("sewer_no")] // Specify the column name
        public string SewerNo { get; set; }

        [Required]
        [Column("paid_amount")] // Specify the column name
        public decimal PaidAmount { get; set; }

        [Required]
        [Column("balance_amount")] // Specify the column name
        public decimal BalanceAmount { get; set; }

        [Required]
        [Column("payment_date")] // Specify the column name
        public DateTime PaymentDate { get; set; }
    }
}

