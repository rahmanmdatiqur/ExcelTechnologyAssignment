using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortalAPI.Models
{
    public class Allergies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AllergiesId { get; set; }
        public string AllergiesName { get; set; } = null!;

        //Navigation
        public virtual ICollection<Allergies_Details> Allergies_Details { get; set; }= new List<Allergies_Details>();
    }
}
