﻿using System;
using System.Collections.Generic;

namespace ZApiproject.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public short RoleId { get; set; }
        public string RoleDesc { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
