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
    public class IndexModel : PageModel
    {
        private readonly ProParcv4.EntityFrameworkCore.ProParcv4DbContext _context;

        public IndexModel(ProParcv4.EntityFrameworkCore.ProParcv4DbContext context)
        {
            _context = context;
        }

        public IList<Vehicule> Vehicule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Vehicule = await _context.Vehicules.ToListAsync();
        }
    }
}
