using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAssessment.Models;
namespace WebApiAssessment.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "USA", Capital = "Washington D.C" }
        };

        // GET: api/country
        [HttpGet]
        public IHttpActionResult GetAllCountries()
        {
            return Ok(countries);
        }

        // GET: api/country/1
        [HttpGet]
        public IHttpActionResult GetCountryById(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        // POST: api/country
        [HttpPost]
        public IHttpActionResult AddCountry([FromBody] Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            country.ID = countries.Max(c => c.ID) + 1; 
            countries.Add(country);
            return CreatedAtRoute("DefaultApi", new { id = country.ID }, country);
        }

        // PUT: api/country/1
        [HttpPut]
        public IHttpActionResult UpdateCountry(int id, [FromBody] Country updatedCountry)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }

            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/country/1
        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }

            countries.Remove(country);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
