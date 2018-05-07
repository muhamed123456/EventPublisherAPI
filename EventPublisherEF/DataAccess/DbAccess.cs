using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPublisherEF.DataAccess;

namespace EventPublisherEF.DataAccess
{
    public class DbAccess: IDbAccess
    {
        public EventPublisherDBEntities GetContext()
        {
            return new EventPublisherDBEntities(); 
        }
    }
}
