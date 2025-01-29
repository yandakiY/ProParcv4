using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProParcv4.EntityFrameworkCore;
using ProParcv4.Vehicules;

namespace ProParcv4.Pages.vehicules
{
    public class DeleteModel : PageModel
    {
        private readonly ProParcv4.EntityFrameworkCore.ProParcv4DbContext _context;

        public DeleteModel(ProParcv4.EntityFrameworkCore.ProParcv4DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehicule Vehicule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicules.FirstOrDefaultAsync(m => m.Id == id);

            if (vehicule is not null)
            {
                Vehicule = vehicule;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicules.FindAsync(id);
            if (vehicule != null)
            {
                Vehicule = vehicule;
                _context.Vehicules.Remove(Vehicule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
