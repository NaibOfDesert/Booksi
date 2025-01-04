using Microsoft.AspNetCore.Mvc.Rendering;
using Booksi.Models.Model;

namespace Booksi.Models.ViewModel{
    public class BookVM{
        public Book Book{ get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}