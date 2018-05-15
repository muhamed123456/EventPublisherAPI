using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPublisherEF.DataRepository;
using EventPublisherEF;
using EventPublisherEF.Contracts;

namespace EventPublisherBLL
{
    public class AttendancesBLL
    {
        EventRepository _ev;
        public AttendancesBLL(EventRepository eventRepo)
        {
            _ev = eventRepo;
        }
        //GetAllAttendances
        public List<AttendancesInfo> GetAttendanceInfo()
        {
            return _ev.GetAttendanceInfo();
        }
        //GetAttendanceByID
        public List<AttendancesInfo> GetAttendanceInfoById(int id)
        {
            return _ev.GetAttendanceInfoById(id);
        }
    }
}
