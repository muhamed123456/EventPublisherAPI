using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisherEF.Contracts
{
    public class AllEvents
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public System.DateTime StartEvent { get; set; }
        public System.DateTime EndEvent { get; set; }
    }
}
