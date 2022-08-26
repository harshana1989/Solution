using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Entities
{
    public class SubCategoryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int AvalabalOptionsCount { get; set; }
        public int CatagoryId { get; set; }
        public bool? IsActive { get; set; }
    }
}
