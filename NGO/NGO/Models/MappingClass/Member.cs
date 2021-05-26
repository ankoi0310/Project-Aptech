using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace NGO.Models.MappingClass
{
    [Table("Member")]
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("Name", TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column("Phone", TypeName = "nvarchar(50)")]
        public string Phone { get; set; }
        [Column("Email", TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Column("BankAccount", TypeName = "nvarchar(50)")]
        public string BankAccount { get; set; }
        [Column("BankName", TypeName = "nvarchar(50)")]
        public string BankName { get; set; }
        [Column("Username", TypeName = "nvarchar(50)")]
        public string Username { get; set; }
        [Column("Password", TypeName = "nvarchar(50)")]
        public string Password { get; set; }

        [Column("MemberTypeId", TypeName = "int")]
        public int MemberTypeId { get; set; }
        [ForeignKey("MemberTypeId")]
        public MemberType MemberType { get; set; }

        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }
    }
}