using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace HRManager.Pages.Beneficios
{
    public class IndexModel : PageModel
    {
        private readonly ManagerContext _context;

        public IndexModel(ManagerContext context)
        {
            _context = context;
        }

        public IList<Beneficio> Beneficios { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Beneficios != null)
            {
                Beneficios = await _context.Beneficios.ToListAsync();
            }

        }
    }
}
