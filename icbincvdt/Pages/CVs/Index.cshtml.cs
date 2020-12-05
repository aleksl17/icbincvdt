using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using icbincvdt.Models;

namespace icbincvdt.Pages.CVs
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCVContext _context;

        public IndexModel(RazorPagesCVContext context)
        {
            _context = context;
        }

        public IList<CV> CV { get;set; }

        public async Task OnGetAsync()
        {
            CV = await _context.CV.ToListAsync();
        }
    }
}
