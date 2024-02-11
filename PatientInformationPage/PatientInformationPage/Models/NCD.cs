using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPage.Models
{
    public class NCD
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NCDId { get; set; }
        public string NCDName { get; set; } = null!;

        //Navigation
        public ICollection<NCD_Details> NCDDetails { get; set; } = new List<NCD_Details>();
    }
}
