using System;
using System.Collections.Generic;

namespace Application.DataContext
{
    public partial class Options
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
