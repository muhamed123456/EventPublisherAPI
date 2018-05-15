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
    public class TypesBLL
    {
        EventRepository _ev;
        public TypesBLL(EventRepository eventRepo)
        {
            _ev = eventRepo;
        }

        //GetAllTypes
        public List<TypesInfo> GetTypeInfo()
        {
            return _ev.GetTypeInfo();
        }
        //GetTypesByID
        public List<TypesInfo> GetTypeInfoById(int id)
        {
            return _ev.GetTypeInfoById(id);
        }
        //Insert
        public void AddType(int id, string type)
        {
            _ev.AddType(id, type);
        }
        //Delete(ID)
        public void DeleteType(int id)
        {
            _ev.DeleteType(id);
        }
    }
}
