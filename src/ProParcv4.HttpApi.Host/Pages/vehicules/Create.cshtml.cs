using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProParcv4.EntityFrameworkCore;
using ProParcv4.Vehicules;

namespace ProParcv4.Pages.vehicules
{
    public class CreateModel : PageModel
    {
        private readonly ProParcv4.EntityFrameworkCore.ProParcv4DbContext _context;

        public CreateModel(ProParcv4.EntityFrameworkCore.ProParcv4DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vehicule Vehicule { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vehicules.Add(Vehicule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
