

namespace FurFiestaApp.Models
{
public class Pet
{
    public int PetID { get; set; }
    public int OwnerID { get; set; } // Foreign key
    public User Owner { get; set; } // Navigation property
    public string Name { get; set; }
    public string Species { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
}
}