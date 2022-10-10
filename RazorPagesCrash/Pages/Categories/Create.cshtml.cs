using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCrash.Data;
using RazorPagesCrash.Model;

namespace RazorPagesCrash.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set;}

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(String.Empty, "The DisplayOrder cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
