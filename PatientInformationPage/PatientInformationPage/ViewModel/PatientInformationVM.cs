using PatientInformationPage.Models;

namespace PatientInformationPage.ViewModel
{
    public class PatientInformationVM
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;

        public int DiseaseId { get; set; }
        public Epilepsy Epilepsy { get; set; }
        public List<int> NCDs { get; set; } = new();
        public List<int> Allergies { get; set; } = new();
    }
}
