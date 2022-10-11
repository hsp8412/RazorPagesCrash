using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCrash.Data;
using RazorPagesCrash.Model;

namespace RazorPagesCrash.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set;}

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
/*          Category = _db.Category.First(u => u.ID == id);
            Category = _db.Category.FirstOrDefault(u => u.ID == id);
            Category = _db.Category.Single(u => u.ID == id);
            Category = _db.Category.SingleOrDefault(u => u.ID == id);
            Category = _db.Category.Where(u => u.ID == id).FirstOrDefault();*/
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
