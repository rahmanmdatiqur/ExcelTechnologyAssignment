using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPage.Models
{
    public class NCD_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NCD_DetailsId { get; set; }
        [ForeignKey(nameof(PatientInformation))]
        public int PatientId { get; set; }
        [ForeignKey(nameof(NCD))]
        public int NCDId { get; set; }

        //Navigation
        public virtual NCD NCD { get; set; } = null!;
        public virtual PatientInformation PatientInformation { get; set; } = null!;
    }
}
