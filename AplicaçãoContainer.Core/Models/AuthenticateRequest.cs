﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaçãoContainer.Core.Models
{
    public class AuthenticateRequest
    {
        public string? email {  get; set; }
        public string? password { get; set; }
    }
}
