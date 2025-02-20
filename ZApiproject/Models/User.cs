﻿using System;
using System.Collections.Generic;

namespace ZApiproject.Models
{
    public partial class User
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public int UserId { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public short RoleId { get; set; }
        public int PubId { get; set; }
        public DateTime? HireDate { get; set; }

        public virtual Publisher Pub { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
