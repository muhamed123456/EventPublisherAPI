using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisherEF.Contracts
{
    public class SearchedEvents
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Place { get; set; }
        public string Type { get; set; }
        public System.DateTime StartEvent { get; set; }
        public System.DateTime EndEvent { get; set; }
        
    }
}
