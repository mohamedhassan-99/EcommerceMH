using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.InputModel
{
    public class ProductInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid BrandId { get; set; }
        public List<Guid> CategoriesIds { get; set; }

    }
}
