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
        public List<SearchedEvents> GetEventInfo()
        {
            return _dbContext.Events.Where(e => e.Approved == true).Select(e => new SearchedEvents
            {
                ID = e.ID,
                Name = e.Name,
                Description = e.Description,
                City = e.City.Name,
                Place = e.Place.PlaceName,
                Type = e.Type.Type1,
                StartEvent = e.StartEvent,
                EndEvent = e.EndEvent
            })
            .ToList();
        }


        //Create Event
        public void CreateEvent(Event event1)
        {
            event1.ID = 0;

            _dbContext.Events.Add(event1);
            _dbContext.SaveChanges();
        }

        //Edit an Event
        public void UpdateEvent(int id, Event event1)
        {
            var event2 = _dbContext.Events.First(e => e.Approved && e.ID == id);
            event2.ID = id;
            event2.Name = event1.Name;
            event2.ID_City = event1.ID_City;
            event2.ID_Type = event1.ID_Type;
            event2.ID_Place = event1.ID_Place;
            event2.Description = event1.Description;
            event2.StartEvent = event1.StartEvent;
            event2.EndEvent = event1.EndEvent;
            event2.Approved = event1.Approved;

            _dbContext.SaveChanges();
        }


        //Search for Event by ID
        public List<SearchedEvents> GetEventInfoById(int id)
        {
            return _dbContext.Events.Where(e => e.ID == id && e.Approved == true).Select(e => new SearchedEvents
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


        //Search for Event by City
        public List<SearchedEvents> GetEventInfoByCity(string city)
        {
            return _dbContext.Events.Where(e => e.City.Name == city && e.Approved == true).Select(e => new SearchedEvents
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

        //Search for Event by Type
        public List<SearchedEvents> GetEventInfoByType(string type)
        {
            return _dbContext.Events.Where(e => e.Type.Type1 == type && e.Approved == true).Select(e => new SearchedEvents
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
            return _dbContext.Cities.Select(c => new CitiesInfo { ID = c.ID, Name = c.Name }).ToList();
        }


        //Search for a City by ID
        public List<CitiesInfo> GetCityInfoById(int id)
        {
            return _dbContext.Cities.Where(c => c.ID == id).Select(c => new CitiesInfo { ID = c.ID, Name = c.Name }).ToList();
        }

        //Add a new City
        public void AddCity(City city1)
        {
            city1.ID = 0;
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
        public void AddPlace(Place place1)
        {
            place1.ID = 0;

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
        public List<GetPublishersByNames> GetPublisherInfo()
        {
            return _dbContext.Publishers.Select(p => new GetPublishersByNames
            {
                ID = p.ID,
                Name = p.Name,
                CompanyName = p.CompanyName,
                Email = p.Email,
                City = p.City.Name
            }).ToList();
        }

        //create publisher
        public void CreatePublisher(Publisher publisher1)
        {
            publisher1.ID = 0;

            _dbContext.Publishers.Add(publisher1);
            _dbContext.SaveChanges();
        }

        //edit publisher's info
        public void UpdatePublisher(int id, Publisher publisher1)
        {
            var pub1 = _dbContext.Publishers.First(p => p.ID == id);

            pub1.Name = publisher1.Name;
            pub1.CompanyName = publisher1.CompanyName;
            pub1.ID_City = publisher1.ID_City;
            pub1.Email = publisher1.Email;
            pub1.PhoneNumber = publisher1.PhoneNumber;
            pub1.ID_User = publisher1.ID_User;

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
        public void AddType(Type type1)
        {
            type1.ID = 0;

            _dbContext.Types.Add(type1);
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
                return _dbContext.Attendances.Where(a => a.ID == id).Select(a => new AttendancesInfo
                {
                    ID = a.ID,
                    attendance = a.Attendance1,
                    eventName = a.Event.Name
                }).ToList();
            }
        }

        //-----------------------------------------------------------------
        //-----------------------------------------------------------------
        //------------------USERS------------------------------------------

        //Get All Users
        public List<UsersInfo> GetUserInfo()
        {
            return _dbContext.Users.Select(u => new UsersInfo
            {
                ID = u.ID,
                Username = u.Username,
                Password = u.Password,
                Role = u.Role.Role1
            }).ToList();
        }

        //Get User by ID
        public List<UsersInfo> GetUserInfoById(int id)
        {

            return _dbContext.Users.Where(u => u.ID == id).Select(u => new UsersInfo
            {
                ID = u.ID,
                Username = u.Username,
                Password = u.Password,
                Role = u.Role.Role1
            }).ToList();
        }

        //Add a new user
        public void AddUser(User user1)
        {
            user1.ID = 0;

            _dbContext.Users.Add(user1);
            _dbContext.SaveChanges();
        }

        //Delete user
        public void DeleteUser(int id)
        {
            _dbContext.Users.Remove(_dbContext.Users.First(u => u.ID == id));
            _dbContext.SaveChanges();
        }

        //-----------------------------------------------------------------
        //-----------------------------------------------------------------
        //------------------ROLES------------------------------------------

        public List<RolesInfo> GetRolesInfo()
        {
            return _dbContext.Roles.Select(r => new RolesInfo
            {
                ID = r.ID,
                Role = r.Role1
            }).ToList();
        }


        public List<RolesInfo> GetRolesInfoByID(int id)
        {
            return _dbContext.Roles.Where(r => r.ID == id).Select(r => new RolesInfo
            {
                ID = r.ID,
                Role = r.Role1
            }).ToList();
        }

        public void AddRole(Role role1)
        {
            role1.ID = 0;

            _dbContext.Roles.Add(role1);
            _dbContext.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            _dbContext.Roles.Remove(_dbContext.Roles.First(r => r.ID == id));
            _dbContext.SaveChanges();
        }


    }
}