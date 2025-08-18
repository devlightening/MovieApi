using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Persistance.Identity
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; } // Migration'daki column name ile eşleştirdik
        public string? ImageUrl { get; set; }
    }
}
