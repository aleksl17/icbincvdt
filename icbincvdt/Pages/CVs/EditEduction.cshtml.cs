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
    public class EditEducationModel : PageModel
    {
        private readonly icbincvdt.Data.ApplicationDbContext _context;

        public EditEducationModel(icbincvdt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Education Education { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Education = await _context.Educations.FirstOrDefaultAsync(m => m.EducationID == id);

            if (Education == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var educationToUpdate = await _context.Educations.FindAsync(id);

            if (educationToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Education>(
                educationToUpdate,
                "Education",
                c => c.EducationTitle,
                c => c.EducationText,
                c => c.EducationDateBegin,
                c => c.EducationDateEnd))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./MyCVs");
            }

            return Page();
        }

        private bool EducationExist(int id)
        {
            return _context.Educations.Any(e => e.EducationID == id);
        }
    }
}