using Microsoft.AspNetCore.Mvc.Rendering;
using Booksi.Models.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Booksi.Models.ViewModel{
    public class ShoppingCardVM{
        public IEnumerable<ShoppingCard> shoppingCards { get; set; }
        [ValidateNever]
        public double totalPrice { get; set; }
    }
}