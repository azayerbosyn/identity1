using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using identity1.Models;

namespace identity1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<identity1.Models.Student> Student { get; set; }
        public DbSet<identity1.Models.StudyEvent> StudyEvent { get; set; }
        public DbSet<identity1.Models.Commander> Commander { get; set; }
        public DbSet<identity1.Models.Group> Group { get; set; }
    }
}
