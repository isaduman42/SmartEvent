

namespace SmartEvent.API.Models
{
    public class User
    {
        public string Id { get; set; }  // GUID veya başka bir sistemle eşleşebilir
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }  // örn: "Admin", "Attendee"
    }
}