using MunicipalityElections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityElections.ViewModels
{
    public class CityViewModel
    {
        public IEnumerable<City> CityList { get; set; }
        public List<City> CitiesList { get; set; }

        public City City { get; set; }
        [Required]
        [Range(2019,2019)]
        public int Year { get; set; }
    }
}