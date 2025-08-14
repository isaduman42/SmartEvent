

namespace SmartEvent.API.Models
{
    public class User
    {
        public string Id { get; set; } = string.Empty;  // Firebase'den gelen UID
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
}
    }
