using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ApplicationDbContext _db; 
    public CategoryController(ILogger<CategoryController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index(){
        List<Category> categories = _db.Categories.ToList();
        return View(categories);
    }
    
    public IActionResult Create(){
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Category category){
        int result;
        if(int.TryParse(category.Name,out result)){
            ModelState.AddModelError("", "Name cannot be a number");
        }
        if(ModelState.IsValid){
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else return View();
    }
}