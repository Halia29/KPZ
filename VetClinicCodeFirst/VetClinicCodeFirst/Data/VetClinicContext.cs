using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetClinicCodeFirst.Models;

namespace VetClinicCodeFirst.Data
{
    public class VetClinicContext : DbContext
    {
        public VetClinicContext (DbContextOptions<VetClinicContext> options)
            : base(options)
        {
        }

        public DbSet<VetClinicCodeFirst.Models.Patient> Patient { get; set; } = default!;

        public DbSet<VetClinicCodeFirst.Models.Visit> Visit { get; set; }
    }
}
