﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameShop.ViewModels.System.Users
{
    public class AdminLoginRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
