using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Beneficios
{
	[Authorize]
	public class DeleteModel : PageModel
    {
        private readonly ManagerContext _context;

        public DeleteModel(ManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Beneficio Beneficio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Beneficios == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficios.FirstOrDefaultAsync(m => m.Id == id);

            if (beneficio == null)
            {
                return NotFound();
            }
            else
            {
                Beneficio = beneficio;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Beneficios == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficios.FindAsync(id);

            if (beneficio != null)
            {
                Beneficio = beneficio;
                _context.Beneficios.Remove(beneficio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
