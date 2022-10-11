using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCrash.Data;
using RazorPagesCrash.Model;

namespace RazorPagesCrash.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set;}

        public DeleteModel(ApplicationDbContext db)
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
            var catelogFromDb = _db.Category.Find(Category.ID);
            if (catelogFromDb != null)
            {
                _db.Category.Remove(catelogFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category deleted Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
