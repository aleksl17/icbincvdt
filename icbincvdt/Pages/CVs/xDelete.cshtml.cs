using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using icbincvdt.Data;
using icbincvdt.Models;

namespace icbincvdt.Pages.CVs
{
    public class DeleteModel : PageModel
    {
        private readonly icbincvdt.Data.ApplicationDbContext _context;

        public DeleteModel(icbincvdt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CV CV { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            CV = await _context.CVs
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CVID == id);

            if (CV == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.CVs.FindAsync(id);

            if (cv == null)
            {
                return NotFound();
            }

            try
            {
                _context.CVs.Remove(cv);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch(DbUpdateException)
            {
                return RedirectToAction("./Delete", new {id, saveChangesError = true});
            }
        }
    }
}
