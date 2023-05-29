using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroConnectCSharpClient.Models
{
    public class TokenResponseData
    {
        public string Token { get; set; }

        public string User { get; set; }

        public DateTime Expires { get; set; }
    }
}
