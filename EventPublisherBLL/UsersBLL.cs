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

        public UsersAndRoles GetUserAndRoles(string username, string password)
        {
            return _ev.GetUserAndRoles().ToList().FirstOrDefault(x => x.UserName == username && x.Password == password);
        }

        public UsersBLL(EventRepository eventRepo)
        {
            _ev = eventRepo;
        }

        public List<UsersInfo> GetUserInfo()
        {
            return _ev.GetUserInfo();
        }

        public List<UsersInfo> GetUserInfoById(int id)
        {
            return _ev.GetUserInfoById(id);
        }

        public void AddUser(User user)
        {
            user.Password = Crypto.CreateMD5(user.Password);
            _ev.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            _ev.DeleteUser(id);
        }
    }
}
