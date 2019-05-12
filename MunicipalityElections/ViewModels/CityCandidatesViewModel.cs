using MunicipalityElections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MunicipalityElections.ViewModels
{
    public class CityCandidatesViewModel
    {
        public IEnumerable<Candidate> ICityCandidates { get; set; }

        public List<Candidate> CityCandidates { get; set; }


        public City City { get; set; }
    }
}