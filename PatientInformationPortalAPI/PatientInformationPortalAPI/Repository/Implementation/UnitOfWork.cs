using PatientInformationPortalAPI;
using PatientInformationPortalAPI.Models;
using PatientInformationPortalAPI.Repository.Abstraction;

namespace PatientInformationPortalAPI.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PatientDbContext _context;

        public IRepository<PatientInformation> PatientInformation { get; }

        public IRepository<DiseaseInformation> DiseaseInformation { get; }

        public IRepository<Allergies> Allergies { get; }

        public IRepository<Allergies_Details> Allergies_Details { get; }

        public IRepository<NCD> NCD { get; }

        public IRepository<NCD_Details> NCD_Details { get; }
        public UnitOfWork(PatientDbContext context, IRepository<PatientInformation> patientInformation, IRepository<DiseaseInformation> diseaseInformation, IRepository<Allergies> allergies, IRepository<Allergies_Details> allergies_Details, IRepository<NCD> nCD, IRepository<NCD_Details> nCD_Details)
        {
            _context = context;
            PatientInformation = patientInformation;
            DiseaseInformation = diseaseInformation;
            Allergies = allergies;
            Allergies_Details = allergies_Details;
            NCD = nCD;
            NCD_Details = nCD_Details;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollBackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }
    }
}
