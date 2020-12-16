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
    public class EditExperienceModel : PageModel
    {
        private readonly icbincvdt.Data.ApplicationDbContext _context;

        public EditExperienceModel(icbincvdt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Experience Experience { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Experience = await _context.Experiences.FirstOrDefaultAsync(m => m.ExperienceID == id);

            if (Experience == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var experienceToUpdate = await _context.Experiences.FindAsync(id);

            if (experienceToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Experience>(
                experienceToUpdate,
                "Experience",
                c => c.ExperienceTitle,
                c => c.ExperienceText,
                c => c.ExperienceDateBegin,
                c => c.ExperienceDateEnd))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./MyCVs");
            }

            return Page();
        }

        private bool ExperienceExist(int id)
        {
            return _context.Experiences.Any(e => e.ExperienceID == id);
        }
    }
}