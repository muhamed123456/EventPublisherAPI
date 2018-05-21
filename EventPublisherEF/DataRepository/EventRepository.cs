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

        //Select All Events
        public List<AllEvents> GetEventInfo()
        {
            return _dbContext.Events.Where(e => e.Approved == true).Select(e => new AllEvents
            { ID= e.ID, Name=e.Name, StartEvent=e.StartEvent, EndEvent=e.EndEvent})
            .ToList();
        }

        
        //Create Event
        public void CreateEvent(string name, string description, int idCity, int idPlace, int idType, System.DateTime startDate, System.DateTime endDate, bool approved)
        {
            Event event1 = new Event();
            event1.Name = name;
            event1.Description = description;
            event1.ID_City = idCity;
            event1.ID_Place = idPlace;
            event1.ID_Type = idType;
            event1.StartEvent = startDate;
            event1.EndEvent = endDate;
            event1.Approved = approved;

            _dbContext.Events.Add(event1);
            _dbContext.SaveChanges();
        }

        //Edit an Event
        public void UpdateEvent(int id, string name, string description, string cityName, string placeName, string typeName, System.DateTime startDate, System.DateTime endDate, bool approved)
        {
            var event2 = _dbContext.Events.First(e => e.Approved && e.ID == id);
            event2.City.Name = cityName;
            event2.Type.Type1 = typeName;
            event2.Place.PlaceName = placeName;
            event2.Description = description;
            event2.StartEvent = startDate;
            event2.EndEvent = endDate;

            _dbContext.SaveChanges();
        }


        //Search for Event by ID
        public List<SearchedEvents> GetEventInfoById(int id)
        {
            return _dbContext.Events.Where(e => e.ID == id && e.Approved==true).Select(e => new SearchedEvents{
                ID = e.ID, Name = e.Name,
                Description = e.Description,
                City = e.City.Name,
                Place = e.Place.PlaceName,
                Type = e.Type.Type1,
                StartEvent = e.StartEvent,
                EndEvent = e.EndEvent }).ToList();
        }


        //Search for Event by Name
        public List<SearchedEvents> GetEventInfoByName(string name)
        {
            return _dbContext.Events.Where(e => e.Name == name && e.Approved==true).Select(e => new SearchedEvents
            {
                ID = e.ID,
                Name = e.Name,
                Description = e.Description,
                City = e.City.Name,
                Place = e.Place.PlaceName,
                Type = e.Type.Type1,
                StartEvent = e.StartEvent,
                EndEvent = e.EndEvent
            }).ToList();
        }


        //Delete an existing Event
        public void DeleteEvent(int id)
        {
            _dbContext.Events.Remove(_dbContext.Events.First(e => e.ID == id));
            _dbContext.SaveChanges();
        }


        //-----------------------------------------------------------------
        //-----------------------------------------------------------------
        //-------------------CITIES----------------------------------------


        //Get all Cities
        public List<CitiesInfo> GetCityInfo()
        {
            return _dbContext.Cities.Select(c => new CitiesInfo {ID = c.ID, Name=c.Name }).ToList();
        }


        //Search for a City by ID
        public List<CitiesInfo> GetCityInfoById(int id)
        {
            return _dbContext.Cities.Where(c => c.ID == id).Select(c => new CitiesInfo { ID = c.ID, Name = c.Name }).ToList();
        }

        //Add a new City
        public void AddCity(string Name)
        {
            City city1 = new City();
            city1.Name = Name;
            _dbContext.Cities.Add(city1);
            _dbContext.SaveChanges();
        }

        //Remove a City
        public void DeleteCity(int id)
        {
            _dbContext.Cities.Remove(_dbContext.Cities.First(c => c.ID == id));
            _dbContext.SaveChanges();
        }



        //-----------------------------------------------------------------
        //-----------------------------------------------------------------
        //-------------------PLACES----------------------------------------


        //Get all Places
        public List<PlacesInfo> GetPlaceInfo()
        {
            return _dbContext.Places.Select(p => new PlacesInfo
            {
                ID = p.ID,
                CityName = p.City.Name,
                PlaceName = p.PlaceName
            }).ToList();
        }
        

        //Search for Place by ID
        public List<PlacesInfo> GetPlaceInfoById(int id)
        {
            return _dbContext.Places.Where(p => p.ID == id).Select(p => new PlacesInfo
            {
                ID = p.ID,
                CityName = p.City.Name,
                PlaceName = p.PlaceName
            }).ToList();
        }

        //Add a place
        public void AddPlace(string placeName, int idCity)
        {
            Place place1 = new Place();
            
            place1.PlaceName = placeName;
            place1.ID_City = idCity;

            _dbContext.Places.Add(place1);
            _dbContext.SaveChanges();
        }

        //Delete a place
        public void DeletePlace(int id)
        {
            _dbContext.Places.Remove(_dbContext.Places.First(p => p.ID == id));
            _dbContext.SaveChanges();
        }




        /*-------------------------------------------------------------------------------------
         * ------------------------------------------------------------------------------------
         * -----------------------------------------------------------------------------------
         * -------------------------------------------------------------------------------------
         * -------------------------------------------------------------------------------------
         * -----------------------------------------------------------------------------------*/


        //Get a list of all publishers
        public List<AllPublishers> GetPublisherInfo()
        {
            return _dbContext.Publishers.Select(p => new AllPublishers
            {
                ID = p.ID,
                Name = p.Name,
                CompanyName = p.CompanyName
            }).ToList();
        }

        //create publisher
        public void CreatePublisher(string name, string companyName, string email, int idCity, string phoneNumber, string idUser)
        {
            Publisher pub = new Publisher();

            pub.Name = name;
            pub.CompanyName = companyName;
            pub.Email = email;
            pub.ID_City = idCity;
            pub.PhoneNumber = phoneNumber;
            pub.ID_User = idUser;

            _dbContext.Publishers.Add(pub);
            _dbContext.SaveChanges();
        }

        //edit publisher's info
        public void UpdatePublisher(int id, string name, string companyName, string email, int idCity, string phoneNumber, string idUser)
        {
            var pub1 = _dbContext.Publishers.First(p => p.ID == id);

            pub1.Name = name;
            pub1.CompanyName = companyName;
            pub1.ID_City = idCity;
            pub1.Email = email;
            pub1.PhoneNumber = phoneNumber;
            pub1.ID_User = idUser;

            
            _dbContext.SaveChanges();
        }


        //Search for a publisher by ID
        public List<GetPublishersByNames> GetPublisherInfoByID(int Id)
        {
            return _dbContext.Publishers.Where(p => p.ID == Id).Select(p => new GetPublishersByNames
            {
                ID = p.ID,
                Name = p.Name,
                City = p.City.Name,
                CompanyName = p.CompanyName,
                Email = p.Email
            }).ToList();
        }


        //Search for a publisher by name
        public List<GetPublishersByNames> GetPublisherInfoByName(string name)
        {
            return _dbContext.Publishers.Where(p => p.Name == name).Select(p => new GetPublishersByNames
            {
                ID = p.ID,
                Name = p.Name,
                City = p.City.Name,
                CompanyName = p.CompanyName,
                Email = p.Email
            }).ToList();
        }


        //Search for a publisher by company name
        public List<GetPublishersByNames> GetPublisherInfoByCompanyName(string companyName)
        {
            return _dbContext.Publishers.Where(p => p.CompanyName == companyName).Select(p => new GetPublishersByNames
            {
                ID = p.ID,
                Name = p.Name,
                City = p.City.Name,
                CompanyName = p.CompanyName,
                Email = p.Email
            }).ToList();
        }


        //Delete a publisher
        public void DeletePublisher(int id)
        {
            _dbContext.Publishers.Remove(_dbContext.Publishers.First(p => p.ID == id));
            _dbContext.SaveChanges();
        }

        //----------------------------------------------------------
        //----------------------------------------------------------
        //----------------TYPES-------------------------------------


        //Get all types
        public List<TypesInfo> GetTypeInfo()
        {
            return _dbContext.Types.Select(t => new TypesInfo
            {
                ID = t.ID,
                type = t.Type1
            }).ToList();
        }


        //Get a type by ID
        public List<TypesInfo> GetTypeInfoById(int id)
        {

            return _dbContext.Types.Where(t => t.ID == id).Select(t => new TypesInfo
            {
                ID = t.ID,
                type = t.Type1
            }).ToList();
        }


        //Add new type
        public void AddType(string type)
        {
            Type type2 = new Type();
            type2.Type1 = type;
            _dbContext.Types.Add(type2);
            _dbContext.SaveChanges();
        }

        //Delete a type
        public void DeleteType(int id)
        {
            _dbContext.Types.Remove(_dbContext.Types.First(t => t.ID == id));
            _dbContext.SaveChanges();
        }


        //-----------------------------------------------------------------
        //-----------------------------------------------------------------
        //------------------ATTENDANCES------------------------------------


        //Get all attendances info
        public List<AttendancesInfo> GetAttendanceInfo()
        {
            return _dbContext.Attendances.Select(a => new AttendancesInfo
            {
                ID = a.ID,
                attendance = a.Attendance1,
                eventName = a.Event.Name
            }).ToList();
        }


        //Get attendance info by ID
        public List<AttendancesInfo> GetAttendanceInfoById(int id)
        {
            {
                return _dbContext.Attendances.Where(a => a.ID==id).Select(a => new AttendancesInfo
                {
                    ID = a.ID,
                    attendance = a.Attendance1,
                    eventName = a.Event.Name
                }).ToList();
            }
        }




    }
}
