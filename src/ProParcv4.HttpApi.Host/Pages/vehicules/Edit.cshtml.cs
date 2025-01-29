using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProParcv4.EntityFrameworkCore;
using ProParcv4.Vehicules;

namespace ProParcv4.Pages.vehicules
{
    public class EditModel : PageModel
    {
        private readonly ProParcv4.EntityFrameworkCore.ProParcv4DbContext _context;

        public EditModel(ProParcv4.EntityFrameworkCore.ProParcv4DbContext context)
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

            var vehicule =  await _context.Vehicules.FirstOrDefaultAsync(m => m.Id == id);
            if (vehicule == null)
            {
                return NotFound();
            }
            Vehicule = vehicule;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vehicule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculeExists(Vehicule.Id))
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

        private bool VehiculeExists(Guid id)
        {
            return _context.Vehicules.Any(e => e.Id == id);
        }
    }
}
