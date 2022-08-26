using System;
using System.Collections.Generic;

namespace Application.DataContext
{
    public partial class Items
    {
        public int Id { get; set; }
        public int? SubCatId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? IsActive { get; set; }

        public virtual Subcategory? SubCat { get; set; }
    }
}
