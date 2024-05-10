namespace FurFiestaApp.Models
{
public class Post
{
    public int PostID { get; set; }
    public int UserID { get; set; } // Foreign key
    public User User { get; set; } // Navigation property
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
}
}