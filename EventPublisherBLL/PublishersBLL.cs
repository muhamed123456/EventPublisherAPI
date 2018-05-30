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
        public void CreatePublisher(string name, string companyName, string email, string cityName, string phoneNumber, int idUser)
        {
            _ev.CreatePublisher(name, companyName,  email, cityName, phoneNumber, idUser);
        }
        //Delete(ID)
        public void DeletePublisher(int id)
        {
            _ev.DeletePublisher(id);
        }
        //Update(ID)
        public void UpdatePublisher(int id, string name, string companyName, string email, string cityName, string phoneNumber, int idUser)
        {
            _ev.UpdatePublisher( id,  name,  companyName,  email, cityName,  phoneNumber, idUser);
        }
        // InsertUsers
        public void CreateUser(User user)
        {
            _ev.AddUser(user);
        }
        // InsertRoles
        public void CreateRoles(string Role)
        {
            _ev.AddRole(Role);
        }
    }
}
