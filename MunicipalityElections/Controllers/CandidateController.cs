using MunicipalityElections.Models;
using MunicipalityElections.ViewModels;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MunicipalityElections.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Candidate
        public ActionResult ShowCandidates(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            String filePath = System.Web.Hosting.HostingEnvironment.MapPath(@"/App_LocalResources/Data/Candidates.json");
            var temp = System.IO.File.ReadAllText(filePath);
            List<Candidate> candidatesList = JsonConvert.DeserializeObject<List<Candidate>>(temp);

            IEnumerable<Candidate> CandidatesList = candidatesList;
            CandidatesList = CandidatesList.Where(s => s.cwin!=null && s.cwin.Length == 0);
            CandidatesList = CandidatesList.Where(s => s.cdistrict != null && s.cdistrict.Length != 0);

            if (!String.IsNullOrEmpty(searchString))
            {
                CandidatesList = candidatesList.Where(s => s.cauthority.Contains(searchString)
                                       || s.cdistrict.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    CandidatesList = CandidatesList.OrderByDescending(s => s.cauthority);
                    break;
                case "Date":
                    CandidatesList = CandidatesList.OrderBy(s => s.cdistrict);
                    break;
                case "date_desc":
                    CandidatesList = CandidatesList.OrderByDescending(s => s.cdistrict);
                    break;
                default:
                    CandidatesList = CandidatesList.OrderBy(s => s.cauthority);
                    break;
            }

            return View(CandidatesList.ToList());
        }

        // GET: Candidate
        public ActionResult ShowCandidates2(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            String filePath = System.Web.Hosting.HostingEnvironment.MapPath(@"/App_LocalResources/Data/Candidates.json");
            var temp = System.IO.File.ReadAllText(filePath);
            List<Candidate> candidatesList = JsonConvert.DeserializeObject<List<Candidate>>(temp);

            IEnumerable<Candidate> CandidatesList = candidatesList;
            CandidatesList = CandidatesList.Where(s => s.cwin != null && s.cwin.Length == 0);
            CandidatesList = CandidatesList.Where(s => s.cdistrict != null && s.cdistrict.Length != 0);

            if (!String.IsNullOrEmpty(searchString))
            {
                CandidatesList = candidatesList.Where(s => s.cauthority.Contains(searchString)
                                       || s.cdistrict.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    CandidatesList = CandidatesList.OrderByDescending(s => s.cauthority);
                    break;
                case "Date":
                    CandidatesList = CandidatesList.OrderBy(s => s.cdistrict);
                    break;
                case "date_desc":
                    CandidatesList = CandidatesList.OrderByDescending(s => s.cdistrict);
                    break;
                default:
                    CandidatesList = CandidatesList.OrderBy(s => s.cauthority);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(CandidatesList.ToPagedList(pageNumber, pageSize));
        }
    }


}