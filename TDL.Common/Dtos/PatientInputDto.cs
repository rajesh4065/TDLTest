using System.ComponentModel.DataAnnotations;

namespace TDL.Common
{
    public class PatientInputDto
    {

        [Required]
        public string RecordId { get; set; }

        [Required]
        public string  Conclusion  { get; set; }

        [Required]
        public string 	AuthorisedBy { get; set; }
    }
}
