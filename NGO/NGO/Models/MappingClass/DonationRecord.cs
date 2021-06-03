using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NGO.Models.MappingClass
{
    [Table("DonationRecord")]
    public class DonationRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("PartnerId", TypeName = "int")]
        public int? PartnerId { get; set; }
        [ForeignKey("PartnerId")]
        public Partner Partner { get; set; }

        [Column("MemberId", TypeName = "int")]
        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        [Column("Date", TypeName = "date")]
        public DateTime Date { get; set; }

        [Column("Amount", TypeName = "int")]
        public int Amount { get; set; }

        [Column("Descriptions", TypeName = "nvarchar")]
        public string Descriptions { get; set; }

        [Column("PaymentTypeId", TypeName = "int")]
        public int PaymentTypeId { get; set; }
        [ForeignKey("PaymentTypeId")]
        public PaymentType PaymentType { get; set; }

        [Column("ProgramId", TypeName = "int")]
        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public Program Program { get; set; }

        [Column("TakePart", TypeName = "bit")]
        public bool TakePart { get; set; }
        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }
    }
}