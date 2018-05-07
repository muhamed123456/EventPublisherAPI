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
        public void AddPlace(Place place1)
        {
            _ev.AddPlace(place1);
        }


        //Delete
        public void DeletePlace(int id)
        {
            _ev.DeletePlace(id);
        }
    }
}
