using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.API.Contracts.Request
{
    public class LoginRequestDto
    {
        public string Email { get; init; }
        public string Password { get; init; }

    }
}
