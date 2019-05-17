using MunicipalityElections.Models;
using MunicipalityElections.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms.DataVisualization.Charting;

namespace MunicipalityElections.Controllers
{
    public class CityController : Controller
    {

        // GET: City
        public ActionResult Main()
        {
            String filePath = System.Web.Hosting.HostingEnvironment.MapPath(@"/App_LocalResources/Data/Cities.json");
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
            if  (!ModelState.IsValid)
            {
                String _filePath = System.Web.Hosting.HostingEnvironment.MapPath(@"/App_LocalResources/Data/Cities.json");
                var _temp = System.IO.File.ReadAllText(_filePath);
                List<City> cityList = JsonConvert.DeserializeObject<List<City>>(_temp);

                var viewMoodel = new CityViewModel
                {
                    CityList = cityList,
                    CitiesList = cityList,
                 
                };
                return View("Main", viewMoodel);
            }
            String filePath = System.Web.Hosting.HostingEnvironment.MapPath(@"/App_LocalResources/Data/Candidates.json");
            var temp = System.IO.File.ReadAllText(filePath);
            List<Candidate> CandidatesList = JsonConvert.DeserializeObject<List<Candidate>>(temp);
            List<Candidate> CityCandidates = new List<Candidate>();
            foreach (Candidate candidate in CandidatesList)
            {
                if (candidate.cauthority == viewModel.City.cauthority)
                    if(candidate.cname.Length !=0)
                        CityCandidates.Add(candidate);
            }


            var newViewModel = new CityCandidatesViewModel
            {
                City = viewModel.City,
                CityCandidates = CityCandidates,
                ICityCandidates = CityCandidates
            };

            Chart chart = new Chart();
            
            List<Object> iData = new List<object>();
            DataTable dt = new DataTable();

            dt.Columns.Add("Candidate Name", Type.GetType("System.String"));
            dt.Columns.Add("Votes", Type.GetType("System.Int32"));



            foreach (Candidate candidate in CityCandidates)
            {
                DataRow dr = dt.NewRow();
                if (candidate.cname.Length != 0)
                    dr["Candidate Name"] = candidate.cname;
                else
                    break;
                if (candidate.cvoted.Length == 0)
                    dr["Votes"] = 0;
                else
                    dr["Votes"] = candidate.cvoted;

                dt.Rows.Add(dr);
            }

            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }


            ViewBag.ChartData = iData;
            //return Json(iData, JsonRequestBehavior.AllowGet);
            return View(newViewModel);
        }




    }
}