﻿using Microsoft.AspNetCore.Identity;

namespace School.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Address { get; set; }
        public int Age { get; set; }

    }
}
