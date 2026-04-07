using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    public class RefreshTokenDto
    {
        public required string RefreshToken { get; set; }

        public Guid UserId { get; set; }
    }
}
    