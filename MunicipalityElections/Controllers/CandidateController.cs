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
    public class CandidateController : Controller
    {
        // GET: Candidate
        public ActionResult ShowCandidates()
        {
            String filePath = System.Web.Hosting.HostingEnvironment.MapPath(@"/App_LocalResources/Candidates.json");
            var temp = System.IO.File.ReadAllText(filePath);
            List<Candidate> candidatesList = JsonConvert.DeserializeObject<List<Candidate>>(temp);

            var viewMoodel = new CandidateViewModel
            {
                CandidatesList = candidatesList
            };

            return View(viewMoodel);
        }
    }
}