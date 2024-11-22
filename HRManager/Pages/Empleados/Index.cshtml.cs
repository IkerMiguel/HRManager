using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace HRManager.Pages.Empleados
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ManagerContext _context;

        public IndexModel(ManagerContext context)
        {
            _context = context;
        }

        public IList<Empleado> Empleados { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Empleados != null)
            {
                Empleados = await _context.Empleados
                .Include(e => e.Departamento)
                .Include(e => e.Cargo)
                .ToListAsync();
            }

        }
    }
}
