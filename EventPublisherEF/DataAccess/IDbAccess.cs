using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisherEF.DataAccess
{
    public interface IDbAccess
    {
        EventPublisherDBEntities GetContext();
    }
}
