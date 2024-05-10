
namespace FurFiestaApp.Models
{
public class User
{
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Location { get; set; }
    public List<Pet> Pets { get; set; } // Navigation property
}
}