using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingService.Models
{
    public class ComponentProcessingContext :DbContext
    {
        public ComponentProcessingContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ProcessFinalResponse> ProcessFinal { get; set; }
    }
}
