using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManager.Pages.Nominas
{
    public class CreateModel : PageModel
    {
        private readonly ManagerContext _context;

        public CreateModel(ManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nomina Nomina { get; set; } = default!;
        public List<Empleado> Empleados { get; set; }

        public void OnGet()
        {
            Empleados = _context.Empleados.ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Nominas == null || Nomina == null)
            {
                Empleados = _context.Empleados.ToList();
                return Page();
            }

            _context.Nominas.Add(Nomina);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
