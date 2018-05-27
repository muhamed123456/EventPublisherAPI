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
        List<SearchedEvents> GetEventInfo();
        void DeleteEvent(int id);
        void CreateEvent(string name, string description, string cityName, string placeName, string typeName, System.DateTime startDate, System.DateTime endDate, bool approved);
        void UpdateEvent(int id, string name, string description, string cityName, string placeName, string typeName, System.DateTime startDate, System.DateTime endDate, bool approved);
        List<SearchedEvents> GetEventInfoById(int id);
        List<SearchedEvents> GetEventInfoByName(string name);

        List<CitiesInfo> GetCityInfo();
        List<CitiesInfo> GetCityInfoById(int id);
        void AddCity(string Name);
        void DeleteCity(int id);

        List<PlacesInfo> GetPlaceInfo();
        List<PlacesInfo> GetPlaceInfoById(int id);
        void AddPlace(string placeName, int idCity);
        void DeletePlace(int id);

        List<GetPublishersByNames> GetPublisherInfo();
        void DeletePublisher(int id);
        void CreatePublisher(string name, string companyName, string email, int idCity, string phoneNumber, string idUser);
        void UpdatePublisher(int id, string name, string companyName, string email, int idCity, string phoneNumber, string idUser);
        List<GetPublishersByNames> GetPublisherInfoByID(int Id);
        List<GetPublishersByNames> GetPublisherInfoByName(string name);
        List<GetPublishersByNames> GetPublisherInfoByCompanyName(string companyName);

        List<TypesInfo> GetTypeInfo();
        List<TypesInfo> GetTypeInfoById(int id);
        void AddType(string type);
        void DeleteType(int id);

        List<AttendancesInfo> GetAttendanceInfo();
        List<AttendancesInfo> GetAttendanceInfoById(int id);

        List<UsersInfo> GetUserInfo();
        List<UsersInfo> GetUserInfoById(int id);
        void AddUser(string userName, string passWord, int ID_Role);
        void DeleteUser(int id);

        List<RolesInfo> GetRolesInfo();
        List<RolesInfo> GetRolesInfoById(int id);
        void AddRole(string Role);
        void DeleteRole(int id);
    }
}
