using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Entities
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
