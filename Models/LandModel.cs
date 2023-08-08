using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geoportal.Models
{
    [Table("landrate_payments")]
    public class LandModel 
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("id_number")]
        public string IdNumber { get; set; }

        [Column("total_amount")]
        public decimal TotalAmount { get; set; }

        [Column("paid_amount")]
        public decimal PaidAmount { get; set; }

    
        [Column("balance")]
        public decimal Balance { get; set; }

    
        [Column("payment_date")]
        public DateTime PaymentDate { get; set; }
    }
}