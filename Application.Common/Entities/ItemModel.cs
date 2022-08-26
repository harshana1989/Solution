using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Entities
{
    public class ItemModel
    {
        public int Id { get; set; }
        public int? SubCatId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? IsActive { get; set; }

    }
}
