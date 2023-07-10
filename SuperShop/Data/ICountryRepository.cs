using Microsoft.AspNetCore.Mvc.Rendering;
using SuperShop.Data.Entities;
using SuperShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        // GET COUNTRIES
        Task<Country> GetCountryAsync(City city);

        IQueryable GetCountriesWithCities();

        Task<Country> GetCountryWithCitiesAsync(int id);


        // CRUD CITIES
        Task AddCityAsync(CityViewModel model);

        Task<City> GetCityAsync(int id);

        Task<int> UpdateCityAsync(City city);

        Task<int> DeleteCityAsync(City city);
    }
}
