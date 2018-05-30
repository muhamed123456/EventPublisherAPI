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
    class RolesBLL
    {
        EventRepository _ev;

        public RolesBLL(EventRepository eventRepo)
        {
            _ev = eventRepo;
        }

        public List<RolesInfo> GetRolesInfo()
        {
            return _ev.GetRolesInfo();
        }

        public List<RolesInfo> GetRolesInfoByID(int id)
        {
            return _ev.GetRolesInfoByID(id);
        }

        public void AddRole(string role1)
        {
            _ev.AddRole(role1);
        }

        public void DeleteRole(int id)
        {
            _ev.DeleteRole(id);
        }


    }
}
