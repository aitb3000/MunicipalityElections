using MunicipalityElections.Models;
using MunicipalityElections.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MunicipalityElections.Controllers
{
    public class CityController : Controller
    {

        // GET: City
        public ActionResult Main()
        {
            String filePath = System.Web.Hosting.HostingEnvironment.MapPath(@"/App_LocalResources/Cities.json");
            var temp = System.IO.File.ReadAllText(filePath);
            List<City> cityList = JsonConvert.DeserializeObject<List<City>>(temp);

            var viewMoodel = new CityViewModel
            {
                CityList = cityList,
                CitiesList = cityList
            };

            return View(viewMoodel);
        }


        [HttpPost]
        public ActionResult Search(CityViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
               return View("Main");
            }
            String filePath = System.Web.Hosting.HostingEnvironment.MapPath(@"/App_LocalResources/Candidates.json");
            var temp = System.IO.File.ReadAllText(filePath);
            List<Candidate> CandidatesList = JsonConvert.DeserializeObject<List<Candidate>>(temp);
            List<Candidate> CityCandidates = new List<Candidate>();
            foreach (Candidate candidate in CandidatesList)
            {
                if (candidate.cauthority == viewModel.City.cauthority)
                    CityCandidates.Add(candidate);
            }

            var newViewModel = new CityCandidatesViewModel
            {
                City = viewModel.City,
                CityCandidates = CityCandidates,
                ICityCandidates = CityCandidates
            };

            return View(newViewModel);
        }




    }
}