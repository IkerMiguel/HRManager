using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManager.Pages.Beneficios
{
	[Authorize]
	public class CreateModel : PageModel
    {
        private readonly ManagerContext _context;

        public CreateModel(ManagerContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Beneficio Beneficio { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Beneficios == null || Beneficio == null)
            {
                return Page();
            }

            _context.Beneficios.Add(Beneficio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
