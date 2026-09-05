namespace WorkshopApi.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public int WorkshopId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }  
    }
}
