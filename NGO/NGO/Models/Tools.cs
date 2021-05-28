using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGO.Models
{
    public static class Tools
    {
        static readonly NGOContext context = new();

        // MemberType
        public static string GetMemberType(int id) => context.MemberTypes.Find(id).Name;
    }
}
