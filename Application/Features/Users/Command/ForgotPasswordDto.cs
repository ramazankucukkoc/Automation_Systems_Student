using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Command
{
    public class ForgotPasswordDto
    {
        public string Email { get; set; }
    }
}
