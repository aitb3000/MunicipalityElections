using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MunicipalityElections.Models
{
    public class Mail
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string FromEmail { get; set; }

        [Required]
        [Phone]
        public string Telephone { get; set; }

        [Required]
        [MaxLength(255)]
        public string Message { get; set; }
    }
}