using System;

namespace TDL.Common
{
    public  class PatientSubmitDto
    {
        public string RecordId { get; set; }
     
        public string Conclusion { get; set; }
        public string AuthorisedBy { get; set; }

        public DateTime? LastUpdateDateTime { get; set; }
    }
}
