using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPage.Models
{
    public class DiseaseInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; } = null!;

        //Navigation
        public List<PatientInformation> PatientInformation =new List<PatientInformation>();
    }
}
