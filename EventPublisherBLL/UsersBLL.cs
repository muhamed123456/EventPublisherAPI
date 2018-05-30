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
    public class UsersBLL
    {
        EventRepository _ev;
        public UsersBLL(EventRepository eventRepo)
        {
            _ev = eventRepo;
        }

        public UsersAndRoles GetUserAndRoles(string username, string password)
        {
            return _ev.GetUserAndRoles().ToList().FirstOrDefault(x => x.UserName == username && x.Password == password);
        }

        public List<UsersInfo> GetUserInfo()
        {
            return _ev.GetUserInfo();
        }

        public List<UsersInfo> GetUserInfoById(int id)
        {
            return _ev.GetUserInfoById(id);
        }

        public void AddUser(User user1)
        {
            _ev.AddUser(user1);
        }

        public void DeleteUser(int id)
        {
            _ev.DeleteUser(id);
        }
    }
}