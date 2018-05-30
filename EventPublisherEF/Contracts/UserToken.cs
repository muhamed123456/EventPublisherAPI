using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisherEF.Contracts
{
    public class UserToken
    {
        public int UserID { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

    }
}
