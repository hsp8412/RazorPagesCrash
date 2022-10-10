using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCrash.Data;
using RazorPagesCrash.Model;

namespace RazorPagesCrash.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}
