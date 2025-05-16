// Models/DTOs/DoctorReviewDto.cs
namespace DocLink.DTOs
{
    public class DoctorReviewDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
    }

    public class DoctorReviewUpdateDto : DoctorReviewDto
    {
        public int Id { get; set; }
    }
}