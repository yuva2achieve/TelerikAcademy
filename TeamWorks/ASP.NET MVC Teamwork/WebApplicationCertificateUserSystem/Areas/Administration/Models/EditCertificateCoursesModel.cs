using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCertificateUserSystem.Areas.Administration.Models
{
    public class EditCertificateCoursesModel
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public IEnumerable< CertificateCourseModel> Courses { get; set; }
    }
}