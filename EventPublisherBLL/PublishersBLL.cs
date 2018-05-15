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
        public List<AllPublishers> GetPublishersInfo()
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
        public void CreatePublisher(int id, string name, string companyName, string email, int idCity, string phoneNumber, string idUser)
        {
            _ev.CreatePublisher( id, name, companyName,  email, idCity, phoneNumber, idUser);
        }
        //Delete(ID)
        public void DeletePublisher(int id)
        {
            _ev.DeletePublisher(id);
        }
        //Update(ID)
        public void UpdatePublisher(int id, Publisher pub)
        {
            _ev.UpdatePublisher(id, pub);
        }
    }
}
