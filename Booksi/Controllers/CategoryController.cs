using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Booksi.DataAccess.Data;

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
            TempData["Success"] = "Category Succesfully Created"; 
            return RedirectToAction("Index");
        }
        else return View();
    }

    public IActionResult Edit(int? id){
        if(id == null || id == 0){
            return NotFound();
        }
        Category? category = _db.Categories.FirstOrDefault(x => x.Id == id);
        if(category == null){
            return NotFound();
        }
        return View(category);
    }
    
    [HttpPost]
    public IActionResult Edit(Category category){
        int result;
        if(int.TryParse(category.Name,out result)){
            ModelState.AddModelError("", "Name cannot be a number");
        }
        if(ModelState.IsValid){
            _db.Categories.Update(category);
            _db.SaveChanges();
            TempData["Success"] = "Category Succesfully Edited"; 

            return RedirectToAction("Index");
        }
        else return View();
    }
    

    [ActionName("Delete")]
    public IActionResult Delete(int? id){
        if(id == null || id ==0){
            return NotFound();
        }
        Category? category= _db.Categories.FirstOrDefault(X => X.Id == id);
        if(category == null){
            return NotFound();
        }
        _db.Categories.Remove(category); 
        _db.SaveChanges();
        TempData["Success"] = "Category Succesfully Deleted"; 
        return RedirectToAction ("Index"); 
    }
}

