using System;
using System.Collections.Generic;

namespace Application.DataContext
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            InverseCatagory = new HashSet<Subcategory>();
            Items = new HashSet<Items>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int AvalabalOptionsCount { get; set; }
        public int CatagoryId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Subcategory Catagory { get; set; } = null!;
        public virtual ICollection<Subcategory> InverseCatagory { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
