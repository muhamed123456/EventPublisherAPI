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
    public class PublishersBLL
    {
        EventRepository _ev;
        public PublishersBLL(EventRepository eventRepo)
        {
            _ev = eventRepo;
        }
        //GetAllPubishers
        public List<GetPublishersByNames> GetPublishersInfo()
        {
            return _ev.GetPublisherInfo();
        }
        //GetPublisherByID
        public List<GetPublishersByNames> GetPublisherInfoByID(int id)
        {
            return _ev.GetPublisherInfoByID(id);
        }
        //GetPublisherByName
        public List<GetPublishersByNames> GetPublisherInfoByName(string name)
        {
            return _ev.GetPublisherInfoByName(name);
        }
        //GetPublisherByCompanyName
        public List<GetPublishersByNames> GetPublisherInfoByCompanyName(string companyName)
        {
            return _ev.GetPublisherInfoByCompanyName(companyName);
        }
        //Insert
        public void CreatePublisher(Publisher publisher1)
        {
            _ev.CreatePublisher(publisher1);
        }
        //Delete(ID)
        public void DeletePublisher(int id)
        {
            _ev.DeletePublisher(id);
        }
        //Update(ID)
        public void UpdatePublisher(int id, Publisher publisher1)
        {
            _ev.UpdatePublisher(id, publisher1);
        }
    }
}