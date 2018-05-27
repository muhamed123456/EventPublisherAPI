using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPublisherEF;
using EventPublisherEF.DataRepository;
using EventPublisherEF.Contracts;

namespace EventPublisherBLL
{
    public class PlacesBLL
    {
        EventRepository _ev;

        public PlacesBLL(EventRepository eventRepo)
        {
            _ev = eventRepo;
        }
        //GetAllPlaces
        public List<PlacesInfo> GetAllPlaces()
        {
            return _ev.GetPlaceInfo();
        }

        //get place by id
        public List<PlacesInfo> GetPlaceByID(int id)
        {
            return _ev.GetPlaceInfoById(id);
        }
        //Insert
        public void AddPlace(string placeName, string cityName)
        {
            _ev.AddPlace(placeName, cityName);
        }


        //Delete
        public void DeletePlace(int id)
        {
            _ev.DeletePlace(id);
        }
    }
}
