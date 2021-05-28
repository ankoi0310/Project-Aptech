using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace NGO.Models.MappingClass
{
    [Table("Query")]
    public class Query
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("MemberId", TypeName = "int")]
        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        [Column("ContentQuery", TypeName = "nvarchar")]
        public string ContentQuery { get; set; }

        [Column("ReplyTo", TypeName = "int")]
        public int? ReplyTo { get; set; }
        [ForeignKey("Id")]
        public Query UpperQuery { get; set; }

        List<Query> LowerQueries { get; set; }

        [Column("Active", TypeName = "bit")]
        public bool Active { get; set; }
    }
}