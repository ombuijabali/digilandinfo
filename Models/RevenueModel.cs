using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geoportal.Models
{
    [Table("revenues")] // Specify the table name
    public class RevenueModel
    {
        [Key]
        [Column("id")] // Specify the column name
        public int Id { get; set; }

        [Column("idnumber")] // Specify the column name
        public string Id_Number { get; set; }

        [Column("plotnumber")] // Specify the column name
        public string PlotNumber { get; set; }

        [Column("plotsize")] // Specify the column name
        public double PlotSize { get; set; }

        [Column("name")] // Specify the column name
        public string Name { get; set; }

        [Column("payment")] // Specify the column name
        public double Payment { get; set; }

        [Column("paid")] // Specify the column name
        public double Paid { get; set; }

        [Column("unpaid")] // Specify the column name
        public double Unpaid { get; set; }

        [Column("defaulted")] // Specify the column name
        public double Defaulted { get; set; }

        [Column("date")] // Specify the column name
        public DateTime Date { get; set; }
    }
}
