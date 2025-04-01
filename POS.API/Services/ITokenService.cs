﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Services
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user, IList<string> roles);
    }
}
