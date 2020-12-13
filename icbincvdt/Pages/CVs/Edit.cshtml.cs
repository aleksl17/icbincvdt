using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using icbincvdt.Data;
using icbincvdt.Models;

namespace icbincvdt.Pages.CVs
{
    public class EditModel : PageModel
    {
        private readonly icbincvdt.Data.CVContext _context;

        public EditModel(icbincvdt.Data.CVContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CV CV { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CV = await _context.CVs.FirstOrDefaultAsync(m => m.CVID == id);

            if (CV == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var cvToUpdate = await _context.CVs.FindAsync(id);

            if (cvToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<CV>(
                cvToUpdate,
                "CV",
                c => c.Summary))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool CVExists(int id)
        {
            return _context.CVs.Any(e => e.CVID == id);
        }
    }
}
