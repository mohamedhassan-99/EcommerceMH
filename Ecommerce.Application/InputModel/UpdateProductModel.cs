using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.InputModel
{
    public class UpdateProductModel : CreateProductModel
    {
        public Guid Id { get; set; }
    }
}
