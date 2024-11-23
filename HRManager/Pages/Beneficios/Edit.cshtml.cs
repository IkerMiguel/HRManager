using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Beneficios
{
	[Authorize]
	public class EditModel : PageModel
    {
        private readonly ManagerContext _context;

        public EditModel(ManagerContext context)
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
            Beneficio = beneficio;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Beneficio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficioExists(Beneficio.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BeneficioExists(int id)
        {
            return (_context.Beneficios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
