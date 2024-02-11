using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortalAPI.Models
{
    public class PatientInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        public string PatientName { get; set; }

        [ForeignKey(nameof(DiseaseInformation))]
        public int DiseaseId { get; set; }
        public Epilepsy Epilepsy { get; set; }

        

        //Navigation
        public List<NCD_Details> NCDs { get; set; } = new List<NCD_Details>();
        public List<Allergies_Details> Allergies { get; set; }= new List<Allergies_Details>();
        public virtual DiseaseInformation DiseaseInformation { get; set; }
    }
}
