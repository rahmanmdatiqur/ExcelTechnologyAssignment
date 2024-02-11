using PatientInformationPortalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PatientInformationPortalAPI
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {

        }

        public DbSet<PatientInformation> PatientInformation { get; set; }
        public DbSet<DiseaseInformation> DiseaseInformation { get; set; }
        public DbSet<NCD> NCD { get; set; }
        public DbSet<NCD_Details> NCDDetails { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Allergies_Details> Allergies_details { get; set; }
 
    }
}
