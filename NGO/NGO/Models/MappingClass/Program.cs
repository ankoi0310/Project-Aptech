using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NGO.Models.MappingClass
{
    [Table("Program")]
    public class Program
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("Name", TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column("BeginDate", TypeName = "date")]
        public DateTime BeginDate { get; set; }
        [Column("EndDate", TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Column("Informations", TypeName = "nvarchar")]
        public string Informations { get; set; }
        [Column("DonationLink", TypeName = "nvarchar(50)")]
        public string DonationLink { get; set; }
        [Column("MinDonation", TypeName = "int")]
        public int MinDonation { get; set; }
        [Column("MaxDonation", TypeName = "int")]
        public int MaxDonation { get; set; }
        [Column("NeedAmount", TypeName = "bigint")]
        public long NeedAmount { get; set; }

        [Column("DonationCategoryId", TypeName = "int")]
        public int DonationCategoryId { get; set; }
        [ForeignKey("DonationCategoryId")]
        public DonationCategory DonationCategory { get; set; }

        [Column("StatusId", TypeName = "int")]
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }
    }
}
