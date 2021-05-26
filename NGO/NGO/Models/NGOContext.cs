using Microsoft.EntityFrameworkCore;
using NGO.Models.MappingClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGO.Models
{
    public class NGOContext: DbContext
    {
        public NGOContext(DbContextOptions<NGOContext> options) : base(options)
        {

        }

        public DbSet<Member> Member { get; set; }
        public DbSet<MemberType> MemberTypes { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Models.MappingClass.Program> Programs { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<ProgramImage> ProgramImages { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<DonationCategory> DonationCategories { get; set; }
        public DbSet<DonationRecord> DonationRecords { get; set; }

    }
}
