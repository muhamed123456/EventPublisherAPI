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
        void CreateEvent(Event event1);
        void UpdateEvent(int id, SearchedEvents event1);
        List<SearchedEvents> GetEventInfoById(int id);
        List<SearchedEvents> GetEventInfoByName(string name);

        List<CitiesInfo> GetCityInfo();
        List<CitiesInfo> GetCityInfoById(int id);
        void AddCity(City city);
        void DeleteCity(int id);

        List<PlacesInfo> GetPlaceInfo();
        List<PlacesInfo> GetPlaceInfoById(int id);
        void AddPlace(Place place);
        void DeletePlace(int id);

        List<AllPublishers> GetPublisherInfo();
        void DeletePublisher(int id);
        void CreatePublisher(Publisher pub);
        void UpdateEvent(int id, Publisher pub);
        List<GetPublishersByNames> GetPublisherInfoByID(int Id);
        List<GetPublishersByNames> GetPublisherInfoByName(string name);
        List<GetPublishersByNames> GetPublisherInfoByCompanyName(string companyName);

        List<TypesInfo> GetTypeInfo();
        List<TypesInfo> GetTypeInfoById(int id);
        void AddType(TypesInfo city);
        void DeleteType(int id);

        List<AttendancesInfo> GetAttendanceInfo();
        List<AttendancesInfo> GetAttendanceInfoById(int id);

        List<City> GetCity();

    }
}
