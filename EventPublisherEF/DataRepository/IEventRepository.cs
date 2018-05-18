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
        List<AllEvents> GetEventInfo();
        void DeleteEvent(int id);
        void CreateEvent(int id, string name, string description, string cityName, string placeName, string typeName, System.DateTime startDate, System.DateTime endDate, bool approved);
        void UpdateEvent(int id, SearchedEvents event1);
        List<SearchedEvents> GetEventInfoById(int id);
        List<SearchedEvents> GetEventInfoByName(string name);

        List<CitiesInfo> GetCityInfo();
        List<CitiesInfo> GetCityInfoById(int id);
        void AddCity(int id, string Name);
        void DeleteCity(int id);

        List<PlacesInfo> GetPlaceInfo();
        List<PlacesInfo> GetPlaceInfoById(int id);
        void AddPlace(string placeName, int idCity);
        void DeletePlace(int id);

        List<AllPublishers> GetPublisherInfo();
        void DeletePublisher(int id);
        void CreatePublisher(int id, string name, string companyName, string email, int idCity, string phoneNumber, string idUser);
        void UpdateEvent(int id, Publisher pub);
        List<GetPublishersByNames> GetPublisherInfoByID(int Id);
        List<GetPublishersByNames> GetPublisherInfoByName(string name);
        List<GetPublishersByNames> GetPublisherInfoByCompanyName(string companyName);

        List<TypesInfo> GetTypeInfo();
        List<TypesInfo> GetTypeInfoById(int id);
        void AddType(int id, string type);
        void DeleteType(int id);

        List<AttendancesInfo> GetAttendanceInfo();
        List<AttendancesInfo> GetAttendanceInfoById(int id);


    }
}
