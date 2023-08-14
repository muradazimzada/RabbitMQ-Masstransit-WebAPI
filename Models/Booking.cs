namespace RabbitMQ_Masstransit_WebAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string? PassangerName { get; set; }
        public string? PassportNumber { get; set; }
        public string? Reference { get; set; }
        public string? From { get; set; }
        public string? TO { get; set; }
    }

}
