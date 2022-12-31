using Employee.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Data
{
    public class StaffContext:IdentityDbContext<ApplicationUser>
    {
        public StaffContext(DbContextOptions<StaffContext> options) : base(options)
        {

        }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //public DbSet<Employee.Models.Notice> Notice { get; set; }
        // public object Notices { get; internal set; }
    }
}
