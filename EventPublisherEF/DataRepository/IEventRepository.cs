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
        void UpdateEvent(int id, Event event1);
        List<SearchedEvents> GetEventInfoById(int id);
        List<SearchedEvents> GetEventInfoByName(string name);

        List<CitiesInfo> GetCityInfo();
        List<CitiesInfo> GetCityInfoById(int id);
        void AddCity(CitiesInfo city);
        void DeleteCity(int id);

        List<PlacesInfo> GetPlaceInfo();
        List<PlacesInfo> GetPlaceInfoById(int id);
        void AddPlace(Place place);
        void DeletePlace(int id);

    }
}
