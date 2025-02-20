﻿using System;
using System.Collections.Generic;

namespace ZApiproject.Models
{
    public partial class Store
    {
        public Store()
        {
            Sales = new HashSet<Sale>();
        }

        public string StoreId { get; set; } = null!;
        public string? StoreName { get; set; }
        public string? StoreAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
