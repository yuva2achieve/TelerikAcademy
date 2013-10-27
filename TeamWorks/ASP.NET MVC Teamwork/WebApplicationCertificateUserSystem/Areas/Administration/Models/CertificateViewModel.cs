using CertificateUserSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationCertificateUserSystem.Areas.Administration.Models
{
    public class CertificateViewModel
    {
       [ScaffoldColumn(false)]
        public int Id { get; set; }
        [HiddenInput(DisplayValue=false)]
        public int ForeignKey { get; set; }

        
        public string Title { get; set; }

        public int MinimalMark { get; set; }

        public string Courses { get; set; }
    }
}