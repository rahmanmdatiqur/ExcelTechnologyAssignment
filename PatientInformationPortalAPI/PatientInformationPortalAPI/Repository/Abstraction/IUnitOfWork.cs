using PatientInformationPortalAPI.Models;

namespace PatientInformationPortalAPI.Repository.Abstraction
{
    public interface IUnitOfWork
    {
        IRepository<PatientInformation> PatientInformation { get; }
        IRepository<DiseaseInformation> DiseaseInformation { get; }
        IRepository<Allergies> Allergies { get; }
        IRepository<Allergies_Details> Allergies_Details { get; }
        IRepository<NCD> NCD { get; }
        IRepository<NCD_Details> NCD_Details { get; }

        Task SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();

    }
}
