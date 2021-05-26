using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NGO.Models.MappingClass
{
    [Table("PaymentType")]
    public class PaymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("Name", TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column("Descriptions", TypeName = "nvarchar")]
        public string Descriptions { get; set; }
        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }

        public List<DonationRecord> DonationRecords { get; set; }

    }
}
