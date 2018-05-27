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
    public class EventsBLL
    {
        EventRepository _ev;
        public EventsBLL(EventRepository eventRepo)
        {
            _ev = eventRepo;
        }

        //Get All Events
        public List<SearchedEvents> GetEvents()
        {
            return _ev.GetEventInfo();
        }
        
        //Get events by ID
        public List<SearchedEvents> GetEventsById(int id)
        {
            return _ev.GetEventInfoById(id);
        }
    
        //get events by name
        public List<SearchedEvents> GetEventsByName(string name)
        {
            return _ev.GetEventInfoByName(name);
        }

        //create new event
        public void CreateEvent(string name, string description, string cityName, string placeName, string type, System.DateTime startDate, System.DateTime endDate, bool approved)
        {
            _ev.CreateEvent(name, description, cityName, placeName, type, startDate, endDate, approved);
        }

        //update event info
        public void UpdateEvent(int id, string name, string description, string cityName, string placeName, string type, System.DateTime startDate, System.DateTime endDate, bool approved)
        {
            _ev.UpdateEvent( id, name, description, cityName, placeName, type, startDate, endDate, approved);
        }

        //delete event
        public void DeleteEvent(int id)
        {
            _ev.DeleteEvent(id);
        }

        

       
    }
}
