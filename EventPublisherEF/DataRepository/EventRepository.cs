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

        public void UpdateEvent(int id, SearchedEvents event1)
        {
            var event2 = _dbContext.Events.Where(e => e.Approved && e.ID == id).First();
            event2.City.Name = event1.City;
            event2.Type.Type1 = event1.Type;
            event2.Place.PlaceName = event1.Place;
            event2.Description = event1.Description;
            event2.StartEvent = event1.StartEvent;
            event2.EndEvent = event1.EndEvent;


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

        public List<string> GetCity()
        {
            var gradovi = _dbContext.Cities.Select(c => c.Name).ToList();
            return gradovi;
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

        public void AddCity(int id, string Name)
        {
            City city1 = new City();
            city1.ID = id;
            city1.Name = Name;
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



        /*-------------------------------------------------------------------------------------
         * ------------------------------------------------------------------------------------
         * -----------------------------------------------------------------------------------
         * -------------------------------------------------------------------------------------
         * -------------------------------------------------------------------------------------
         * -----------------------------------------------------------------------------------*/

        public List<AllPublishers> GetPublisherInfo()
        {
            var myPublisher = (from p in _dbContext.Publishers
                               select new AllPublishers()
                               {
                                   Name = p.Name,
                                   CompanyName = p.CompanyName
                               }).ToList();
            return myPublisher;
        }

        public void CreatePublisher(Publisher pub)
        {
            _dbContext.Publishers.Add(pub);
            _dbContext.SaveChanges();
        }

        public void UpdatePublisher(int id, Publisher pub)
        {
            var pub1 = _dbContext.Publishers.Where(p => p.ID == id).First();
            var city1 = _dbContext.Cities.Where(c1 => c1.ID == pub1.ID_City).First();

            pub1.Name = pub.Name;
            pub1.CompanyName = pub.CompanyName;
            pub1.ID_City = city1.ID;
            pub1.Email = pub.Email;
            pub1.PhoneNumber = pub.PhoneNumber;
            pub1.ID_User = pub.ID_User;

            _dbContext.Publishers.Attach(pub1);
            _dbContext.Entry(pub1).State = System.Data.Entity.EntityState.Modified;
        }

        public List<GetPublishersByNames> GetPublisherInfoByID(int Id)
        {
            var myPublisher = (from p in _dbContext.Publishers
                               join c in _dbContext.Cities on p.ID_City equals c.ID
                               where p.ID == Id
                               select new GetPublishersByNames()
                               {
                                   Name = p.Name,
                                   City = c.Name,
                                   CompanyName = p.CompanyName,
                                   Email = p.Email,
                               }).ToList();
            return myPublisher;
        }

        public List<GetPublishersByNames> GetPublisherInfoByName(string name)
        {
            var myPublisher = (from p in _dbContext.Publishers
                               join c in _dbContext.Cities on p.ID_City equals c.ID
                               where p.Name == name
                               select new GetPublishersByNames()
                               {
                                   Name = p.Name,
                                   City = c.Name,
                                   CompanyName = p.CompanyName,
                                   Email = p.Email

                               }).ToList();
            return myPublisher;
        }

        public List<GetPublishersByNames> GetPublisherInfoByCompanyName(string companyName)
        {
            var myPublisher = (from p in _dbContext.Publishers
                               join c in _dbContext.Cities on p.ID_City equals c.ID
                               where p.CompanyName == companyName
                               select new GetPublishersByNames()
                               {
                                   Name = p.Name,
                                   City = c.Name,
                                   CompanyName = p.CompanyName,
                                   Email = p.Email
                               }).ToList();
            return myPublisher;
        }


        public void DeletePublisher(int id)
        {
            var pubDelete = _dbContext.Publishers.Where(p => p.ID == id).First();
            _dbContext.Publishers.Remove(pubDelete);
            _dbContext.SaveChanges();
        }

        //----------------------------------------------------------
        //----------------------------------------------------------
        //----------------TYPES-------------------------------------

        public List<TypesInfo> GetTypeInfo()
        {
            var typeinfo = (from t in _dbContext.Types
                            select new TypesInfo()
                            {
                                type = t.Type1
                            }).ToList();
            return typeinfo;
        }

        public List<TypesInfo> GetTypeInfoById(int id)
        {
            {
                var typeinfo = (from t in _dbContext.Types
                                where t.ID == id
                                select new TypesInfo()
                                {
                                    type = t.Type1
                                }).ToList();
                return typeinfo;
            }
        }

        public void AddType(TypesInfo Type)
        {
            Type Type1 = new Type()
            {
                ID = 0,
                Type1 = Type.type
            };
            _dbContext.Types.Add(Type1);
            _dbContext.SaveChanges();
        }

        public void DeleteType(int id)
        {
            var type = _dbContext.Types.Where(t => t.ID == id).First();
            _dbContext.Types.Remove(type);
            _dbContext.SaveChanges();
        }

        //-----------------------------------------------------------------
        //-----------------------------------------------------------------
        //------------------ATTENDANCES------------------------------------

        public List<AttendancesInfo> GetAttendanceInfo()
        {
            var attinfo = (from a in _dbContext.Attendances
                           select new AttendancesInfo()
                           {
                               attendance = a.Attendance1.ToString()
                           }).ToList();
            return attinfo;
        }

        public List<AttendancesInfo> GetAttendanceInfoById(int id)
        {
            {
                var attinfo = (from a in _dbContext.Attendances
                               where a.ID == id
                               select new AttendancesInfo()
                               {
                                   attendance = a.Attendance1.ToString()
                               }).ToList();
                return attinfo;
            }
        }

        public List<City> GetCityTest()
        {
            return _dbContext.Cities.ToList();
        }



    }
}
