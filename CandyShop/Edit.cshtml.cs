using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using candyshop.Data;

namespace candyshop.Pages.CandyShop
{
    public class EditModel : PageModel
    {
        private readonly candyshop.Data.ApplicationDbContext _context;

        public EditModel(candyshop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cshop Cshop { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cshop = await _context.Cshop.FirstOrDefaultAsync(m => m.CSID == id);

            if (Cshop == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cshop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CshopExists(Cshop.CSID))
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

        private bool CshopExists(int id)
        {
            return _context.Cshop.Any(e => e.CSID == id);
        }
    }
}
