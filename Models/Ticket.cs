public class Ticket
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string UserId { get; set; } // Firebase UID
    public DateTime CreatedAt { get; set; }
    public bool IsCheckedIn { get; set; }
}