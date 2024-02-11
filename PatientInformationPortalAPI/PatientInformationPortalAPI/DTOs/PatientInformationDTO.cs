using PatientInformationPortalAPI.Models;

namespace PatientInformationPortalAPI.DTOs
{
    public class PatientInformationDTO
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;

        public int DiseaseId { get; set; }
        public Epilepsy Epilepsy { get; set; }
        public List<int> NCDs { get; set; } = new();
        public List<int> Allergies { get; set; } = new();
    }
}
