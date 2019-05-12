using MunicipalityElections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MunicipalityElections.ViewModels
{
    public class CandidateViewModel
    {
        public IEnumerable<Candidate> CandidatesList { get; set; }
    }
}