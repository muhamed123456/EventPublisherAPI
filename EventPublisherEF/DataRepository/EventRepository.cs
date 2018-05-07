using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPublisherEF.DataAccess;
using System.Configuration;
using System.Data.SqlClient;
using EventPublisherEF.Contracts;

namespace EventPublisherEF.DataRepository
{
    public class EventRepository
    {
        private EventPublisherDBEntities _dbContext;
        public EventRepository(DbAccess dbAccess)
        {
            _dbContext = dbAccess.GetContext();
        }
        
        public List<AllEvents> GetEventInfo()
        {
            var myEvent = (from e in _dbContext.Events
                           where e.Approved == true
                           select new AllEvents()
                           {
                               Name = e.Name,
                               StartEvent = e.StartEvent,
                               EndEvent = e.EndEvent
                           }).ToList();
            return myEvent;
        }

        public void CreateEvent(Event event1)
        {
            _dbContext.Events.Add(event1);
            _dbContext.SaveChanges();
        }

        public void UpdateEvent(int id, Event event1)
        {
            var event2 = _dbContext.Events.Where(e => e.ID == id && e.Approved).First();
            var city = _dbContext.Cities.Where(c => c.ID == event1.ID_City).First();
            var type = _dbContext.Types.Where(t => t.ID == event1.ID_Type).First();
            var place = _dbContext.Places.Where(p => p.ID == event1.ID_Place).First();

            event2.Name = event1.Name;
            event2.ID_City = city.ID;
            event2.ID_Type = city.ID;
            event2.ID_Place = place.ID;
            event2.StartEvent = event1.StartEvent;
            event2.EndEvent = event1.EndEvent;
            event2.Description = event1.Description;

            _dbContext.Events.Attach(event2);
            _dbContext.Entry(event2).State = System.Data.Entity.EntityState.Modified;                       
        }

        public List<SearchedEvents> GetEventInfoById(int id)
        {
            var myEvent = (from e in _dbContext.Events
                           join c in _dbContext.Cities on e.ID_City equals c.ID
                           join t in _dbContext.Types on e.ID_Type equals t.ID
                           join p in _dbContext.Places on e.ID_Place equals p.ID
                           join a in _dbContext.Attendances on e.ID equals a.ID_Event
                                         where e.Approved == true && e.ID==id
                                         select new SearchedEvents()
                                         {
                                             Name = e.Name,
                                             City = c.Name,
                                             Place = p.PlaceName,
                                             Type = t.Type1,
                                             Description = e.Description,
                                             StartEvent = e.StartEvent,
                                             EndEvent = e.EndEvent,
                                             Attendance = a.Attendance1
                                         }).ToList();
            return myEvent;
        }

        public List<SearchedEvents> GetEventInfoByName(string name)
        {
            var myEvent = (from e in _dbContext.Events
                           join c in _dbContext.Cities on e.ID_City equals c.ID
                           join t in _dbContext.Types on e.ID_Type equals t.ID
                           join p in _dbContext.Places on e.ID_Place equals p.ID
                           join a in _dbContext.Attendances on e.ID equals a.ID_Event
                           where e.Approved == true && e.Name == name
                           select new SearchedEvents()
                           {
                               Name = e.Name,
                               City = c.Name,
                               Place = p.PlaceName,
                               Type = t.Type1,
                               Description = e.Description,
                               StartEvent = e.StartEvent,
                               EndEvent = e.EndEvent,
                               Attendance = a.Attendance1
                           }).ToList();
            return myEvent;
        }
        
        
        public void DeleteEvent(int id)
        {
            var eventDelete = _dbContext.Events.Where(e => e.ID == id).First();
            _dbContext.Events.Remove(eventDelete);
            _dbContext.SaveChanges();
        }

//-----------------------------------------------------------------
//-----------------------------------------------------------------
//-------------------CITIES----------------------------------------

        public List<CitiesInfo> GetCityInfo()
        {
            var cityInfo = (from c in _dbContext.Cities
                           select new CitiesInfo()
                           {
                               Name = c.Name
                           }).ToList();
            return cityInfo;
        }

        public List<CitiesInfo> GetCityInfoById(int id)
        {
            {
                var cityInfo = (from c in _dbContext.Cities
                                where c.ID==id
                                select new CitiesInfo()
                                {
                                    Name = c.Name
                                }).ToList();
                return cityInfo;
            }
        }

        public void AddCity(CitiesInfo city)
        {
            City city1 = new City()
            {
                ID = 0,
                Name = city.Name
            };
            _dbContext.Cities.Add(city1);
            _dbContext.SaveChanges();
        }

        public void DeleteCity(int id)
        {
            var city = _dbContext.Cities.Where(c => c.ID == id).First();
            _dbContext.Cities.Remove(city);
            _dbContext.SaveChanges();
        }


        //-----------------------------------------------------------------
        //-----------------------------------------------------------------
        //-------------------PLACES----------------------------------------

        public List<PlacesInfo> GetPlaceInfo()
        {
            var placeInfo = (from p in _dbContext.Places
                           join c in _dbContext.Cities on p.ID_City equals c.ID
                           select new PlacesInfo()
                           {
                               PlaceName = p.PlaceName,
                               CityName = c.Name,

                           }).ToList();
            return placeInfo;
        }

        public List<PlacesInfo> GetPlaceInfoById(int id)
        {
            var placeInfo = (from p in _dbContext.Places
                             join c in _dbContext.Cities on p.ID_City equals c.ID
                             where p.ID==id
                             select new PlacesInfo()
                             {
                                 PlaceName = p.PlaceName,
                                 CityName = c.Name,

                             }).ToList();
            return placeInfo;
        }

        public void AddPlace(Place place)
        {
            _dbContext.Places.Add(place);
            _dbContext.SaveChanges();
        }

        public void DeletePlace(int id)
        {
            var place = _dbContext.Places.Where(p => p.ID == id).First();
            _dbContext.Places.Remove(place);
            _dbContext.SaveChanges();
        }






    }
}
