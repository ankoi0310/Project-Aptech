using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace NGO.Models.MappingClass
{
    [Table("ProgramImage")]
    public class ProgramImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("Name", TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column("Path", TypeName = "nvarchar")]
        public string Path { get; set; }

        [Column("ProgramId", TypeName = "int")]
        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public Program Program { get; set; }
        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }


        [NotMapped]
        public FormFile SingleFile { get; set; }
        [NotMapped]
        public List<FormFile> MultiFiles { get; set;}
    }
}