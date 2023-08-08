using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geoportal.Models
{
    [Table("permits")]
    public class PermitsModel
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

  
        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("payment_date")]
        public DateTime PaymentDate { get; set; }
    }
}