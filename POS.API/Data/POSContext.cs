﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Data
{
    public class POSContext : IdentityDbContext
    {
        public POSContext(DbContextOptions<POSContext> options) : base(options)
        {
        }
    }
}
