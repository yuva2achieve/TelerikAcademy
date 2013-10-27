using CertificateUserSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebApplicationCertificateUserSystem.Areas.Administration.Models
{
    public class CertificateCourseModel
    {
        public static Expression<Func<Course, CertificateCourseModel>> FromCourse
        {
            get
            {
                return x => new CertificateCourseModel
                {
                    Id = x.Id,
                    Title = x.Title
                };
            }
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
}