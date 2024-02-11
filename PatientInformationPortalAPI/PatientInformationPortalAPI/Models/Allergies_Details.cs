using PatientInformationPortalAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortalAPI.Models
{
    public class Allergies_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Allergies_DetailsId { get; set; }
        [ForeignKey(nameof(PatientInformation))]
        public int PatientId { get; set; }
        [ForeignKey(nameof(Allergies))]
        public int AllergiesId { get; set; }

        //Navigation
        public virtual Allergies Allergies { get; set; } = null!;
        public virtual PatientDbContext PatientInformation { get; set; } = null!;
    }
}
