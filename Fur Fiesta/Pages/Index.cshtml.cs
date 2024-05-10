using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FurFiestaApp.Models;  // Correct namespace for your models
 // Correct namespace for your DbContext


namespace FurFiestaApp.Pages
{
public class IndexModel : PageModel
{
    private readonly PetDbContext _context;

    public IndexModel(PetDbContext context)
    {
        _context = context;
    }

    public IList<Pet> Pets { get; set; }

    public async Task OnGetAsync()
    {
        Pets = await _context.Pets.Include(p => p.Owner).ToListAsync();
    }
}
}