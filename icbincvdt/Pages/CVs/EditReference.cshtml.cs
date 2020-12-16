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
    public class EditReferenceModel : PageModel
    {
        private readonly icbincvdt.Data.ApplicationDbContext _context;

        public EditReferenceModel(icbincvdt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reference Reference { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reference = await _context.References.FirstOrDefaultAsync(m => m.ReferenceID == id);

            if (Reference == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var referenceToUpdate = await _context.References.FindAsync(id);

            if (referenceToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Reference>(
                referenceToUpdate,
                "Reference",
                c => c.ReferenceName,
                c => c.ReferencePhoneNumber))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./MyCVs");
            }

            return Page();
        }

        private bool ReferenceExist(int id)
        {
            return _context.References.Any(e => e.ReferenceID == id);
        }
    }
}