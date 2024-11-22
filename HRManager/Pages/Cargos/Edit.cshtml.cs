using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Cargos
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
        public Cargo Cargo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cargos == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos.FirstOrDefaultAsync(m => m.Id == id);

            if (cargo == null)
            {
                return NotFound();
            }
            Cargo = cargo;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(Cargo.Id))
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

        private bool CargoExists(int id)
        {
            return (_context.Cargos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
