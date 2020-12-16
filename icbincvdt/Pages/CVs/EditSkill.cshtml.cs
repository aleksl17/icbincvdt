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
    public class EditSkillModel : PageModel
    {
        private readonly icbincvdt.Data.ApplicationDbContext _context;

        public EditSkillModel(icbincvdt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Skill Skill { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Skill = await _context.Skills.FirstOrDefaultAsync(m => m.SkillID == id);

            if (Skill == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var skillToUpdate = await _context.Skills.FindAsync(id);

            if (skillToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Skill>(
                skillToUpdate,
                "Skill",
                c => c.SkillTitle,
                c => c.SkillText,
                c => c.SkillRating))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./MyCVs");
            }

            return Page();
        }

        private bool SkillExist(int id)
        {
            return _context.Skills.Any(e => e.SkillID == id);
        }
    }
}