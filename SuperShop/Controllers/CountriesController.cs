using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperShop.Data;
using SuperShop.Data.Entities;
using SuperShop.Models;
using Vereyon.Web;

namespace SuperShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IFlashMessage _flashMessage;

        public CountriesController(
            ICountryRepository countryRepository,
            IFlashMessage flashMessage)
        {
            _countryRepository = countryRepository;
            _flashMessage = flashMessage;
        }
        

        public IActionResult Index()
        {
            return View(_countryRepository.GetCountriesWithCities());
        }


        //------------------------------------------------- COUNTRY -------------------------------------------------

        //#######################################
        //#                CREATE               #
        //#######################################

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _countryRepository.CreateAsync(country);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _flashMessage.Danger("This country already exist in the database.");
                }

                return View(country);
            }

            return View(country);
        }


        //########################################
        //#                DETAILS               #
        //########################################

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _countryRepository.GetCountryWithCitiesAsync(id.Value);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }


        //#####################################
        //#                EDIT               #
        //#####################################

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _countryRepository.GetByIdAsync(id.Value);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                await _countryRepository.UpdateAsync(country);
                return RedirectToAction(nameof(Index));
            }

            return View(country);
        }


        //#######################################
        //#                DELETE               #
        //#######################################

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _countryRepository.GetByIdAsync(id.Value);

            if (country == null)
            {
                return NotFound();
            }

            await _countryRepository.DeleteAsync(country);

            return RedirectToAction(nameof(Index));
        }


        //------------------------------------------------- CITY -------------------------------------------------

        //#######################################
        //#                CREATE               #
        //#######################################

        public async Task<IActionResult> AddCity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _countryRepository.GetByIdAsync(id.Value);

            if (country == null)
            {
                return NotFound();
            }

            var model = new CityViewModel { CountryId = country.Id };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddCity(CityViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _countryRepository.AddCityAsync(model);
                return RedirectToAction("Details", new { id = model.CountryId });
            }

            return View(model);
        }        


        //#####################################
        //#                EDIT               #
        //#####################################

        public async Task<IActionResult> EditCity(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var city = await _countryRepository.GetCityAsync(id.Value);

            if(city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> EditCity(City city)
        {
            if(ModelState.IsValid)
            {
                var countryId = await _countryRepository.UpdateCityAsync(city);

                if(countryId != 0)
                {
                    return RedirectToAction("Details", new { id = countryId });
                }

            }

            return View(city);
        }


        //#######################################
        //#                DELETE               #
        //#######################################

        public async Task<IActionResult> DeleteCity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _countryRepository.GetCityAsync(id.Value);

            if (city == null)
            {
                return NotFound();
            }

            var countryId = await _countryRepository.DeleteCityAsync(city);

            return this.RedirectToAction("Details", new { id = countryId });
        }
    }
}
