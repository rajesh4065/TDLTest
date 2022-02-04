using System;

namespace TDL.Common
{
    public class PatientOutPutDto
    {
        public string Conclusion { get; set; }
        public string AuthorisedBy { get; set; }

        public DateTime LastUpdateDateTime { get; set; }

        public bool Status { get; set; }
    }
}
