namespace TDL.Common
{
    public class PatientDetailsDto
    {
        public PatientDetailsDto()
        {
            PatientSubmitDto = new PatientSubmitDto();
        }
        public string RecordId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public AddressDto Address { get; set; }
        public string HosptialNo { get; set; }
        public string NhsNo { get; set; }
        public string Clinician { get; set; }
        public string Source { get; set; }
        public string SampleDate { get; set; }
        public string RequestDate { get; set; }
        public string OrderNo { get; set; }
        public CerebroDataDto CerebroData { get; set; }

        public PatientSubmitDto PatientSubmitDto { get; set; }
        public bool? Status { get; set; } = null;
    }
}
