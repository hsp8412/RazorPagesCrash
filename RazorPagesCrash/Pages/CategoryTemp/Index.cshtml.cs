﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCrash.Data;
using RazorPagesCrash.Model;

namespace RazorPagesCrash.Pages.CategoryTemp
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCrash.Data.ApplicationDbContext _context;

        public IndexModel(RazorPagesCrash.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Category != null)
            {
                Category = await _context.Category.ToListAsync();
            }
        }
    }
}
