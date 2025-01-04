using Microsoft.AspNetCore.Mvc.Rendering;
using Booksi.Models.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Booksi.Models.ViewModel{
    public class BookVM{
        public Book Book{ get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}