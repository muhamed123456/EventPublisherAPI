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
    public class CitiesBLL
    {

        EventRepository _ev;

        public CitiesBLL(EventRepository eventRepo)
        {
            _ev = eventRepo;
        }

        //GetAllCities
        public List<CitiesInfo> GetCityInfo()
        {
            return _ev.GetCityInfo();
        }

        //get cities by ID
        public List<CitiesInfo> GetCityByID(int id)
        {
            return _ev.GetCityInfoById(id);
        }

        
        //Insert
        public void AddCity(int id, string Name)
        {
            _ev.AddCity(id, Name);
        }


        //Delete(ID)
        public void DeleteCity(int id)
        {
            _ev.DeleteCity(id);
        }


        
    }
}
