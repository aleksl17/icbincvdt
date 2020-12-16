using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using icbincvdt.Data;
using icbincvdt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace icbincvdt.Pages.CVs
{
    [Authorize]
    public class CreateReferenceModel : PageModel
    {
        private readonly icbincvdt.Data.ApplicationDbContext _context;

        public CreateReferenceModel(icbincvdt.Data.ApplicationDbContext context)
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
            
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var emptyReference = new Reference();
            
            if (await TryUpdateModelAsync<Reference>(
                emptyReference,
                "Reference",
                e => e.CVID,
                e => e.ReferenceName,
                e => e.ReferencePhoneNumber))
            {
                _context.References.Add(emptyReference);
                await _context.SaveChangesAsync();
                return RedirectToPage("./MyCVs");
            }

            return Page();
        }
    }
}