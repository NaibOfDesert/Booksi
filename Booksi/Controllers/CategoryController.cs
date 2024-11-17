using Microsoft.AspNetCore.Mvc;

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
        _db.Categories.Add(category);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}