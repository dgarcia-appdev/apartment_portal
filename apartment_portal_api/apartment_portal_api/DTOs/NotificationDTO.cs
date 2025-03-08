namespace apartment_portal_api.DTOs;

    public class NotificationDTO
    {
        public string Type { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime Date { get; set; }
    }
