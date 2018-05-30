using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPublisherEF.DataAccess;
using EventPublisherEF.Contracts;

namespace EventPublisherEF.DataRepository
{
    interface IEventRepository
    {
        //EVENTS
        List<SearchedEvents> GetEventInfo();
        void DeleteEvent(int id);
        void CreateEvent(Event event1);
        void UpdateEvent(int id, Event event1);
        List<SearchedEvents> GetEventInfoById(int id);
        List<SearchedEvents> GetEventInfoByCity(string city);
        List<SearchedEvents> GetEventInfoByType(string type);

        //CITIES
        List<CitiesInfo> GetCityInfo();
        List<CitiesInfo> GetCityInfoById(int id);
        void AddCity(City city1);
        void DeleteCity(int id);

        //PLACES
        List<PlacesInfo> GetPlaceInfo();
        List<PlacesInfo> GetPlaceInfoById(int id);
        void AddPlace(Place place1);
        void DeletePlace(int id);

        //PUBLISHERS
        List<GetPublishersByNames> GetPublisherInfo();
        void DeletePublisher(int id);
        void CreatePublisher(Publisher publisher1);
        void UpdatePublisher(int id, Publisher publisher1);
        List<GetPublishersByNames> GetPublisherInfoByID(int Id);
        List<GetPublishersByNames> GetPublisherInfoByName(string name);
        List<GetPublishersByNames> GetPublisherInfoByCompanyName(string companyName);

        //TYPES
        List<TypesInfo> GetTypeInfo();
        List<TypesInfo> GetTypeInfoById(int id);
        void AddType(Type type1);
        void DeleteType(int id);


        //ATTENDANCES
        List<AttendancesInfo> GetAttendanceInfo();
        List<AttendancesInfo> GetAttendanceInfoById(int id);


        //USERS
        List<UsersInfo> GetUserInfo();
        List<UsersInfo> GetUserInfoById(int id);
        void AddUser(User user1);
        void DeleteUser(int id);

        
        //ROLES
        List<RolesInfo> GetRolesInfo();
        List<RolesInfo> GetRolesInfoById(int id);
        void AddRole(Role role1);
        void DeleteRole(int id);
    }
}