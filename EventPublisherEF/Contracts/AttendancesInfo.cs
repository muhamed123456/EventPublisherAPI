using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPublisherEF.Contracts
{
    public class AttendancesInfo
    {
        public int ID { get; set; }
        public int attendance { get; set; }
        public string eventName { get; set; }
    }
}
