namespace WorkshopApi.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Venue { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public DateTime RegistrationDeadline { get; set; }
    }
}
