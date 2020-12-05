using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using icbincvdt.Models;

namespace icbincvdt.Pages.CVs
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesCVContext _context;

        public CreateModel(RazorPagesCVContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CV CV { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CV.Add(CV);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
