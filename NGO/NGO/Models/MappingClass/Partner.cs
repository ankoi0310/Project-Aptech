using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace NGO.Models.MappingClass
{
    [Table("Partner")]
    public class Partner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("Name", TypeName = "nvarchar")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("Address", TypeName = "nvarchar")]
        [StringLength(50)]
        public string Address { get; set; }
        [Column("Information", TypeName = "nvarchar")]
        public string Information { get; set; }                
        [Column("LogoImage", TypeName = "nvarchar")]
        public string LogoImage { get; set; }
        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }
        [NotMapped]
        [DisplayName("Upload Image")]
        //[Required(ErrorMessage = "This field is required.")]
        public IFormFile ImageFile { get; set; }
        public List<DonationRecord> DonationRecords { get; set; }
    }
}