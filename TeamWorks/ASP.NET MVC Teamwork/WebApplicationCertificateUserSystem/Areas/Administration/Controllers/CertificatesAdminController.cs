using CertificateUserSystem.Data;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using WebApplicationCertificateUserSystem.Areas.Administration.Models;
using CertificateUserSystem.Models;
using System.Text;

namespace WebApplicationCertificateUserSystem.Areas.Administration.Controllers
{
    public class CertificatesAdminController : BaseController
    {
        public CertificatesAdminController()
            : this(new UowData())
        {

        }
        public CertificatesAdminController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            var certificates = this.Data.Certificates.All().ToList();
            var models = new List<CertificateViewModel>();
            foreach (var certificate in certificates)
            {
                var model = this.FromCertificate(certificate);
                models.Add(model);
            }

            return View(models);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var certificates = this.Data.Certificates.All().ToList();
            var models = new List<CertificateViewModel>();
            foreach (var certificate in certificates)
            {
                var model = this.FromCertificate(certificate);
                models.Add(model);
            }

            return Json(models.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CertificateViewModel model)
        {
            CertificateViewModel newModel = model;

            if (model != null && ModelState.IsValid)
            {
                var certificateInDb = this.Data.Certificates.GetById(model.Id);
                string[] newCertificateCourses = model.Courses.Split(',');
                certificateInDb.MinimalMark = model.MinimalMark;
                certificateInDb.Title = model.Title;
                this.Data.SaveChanges();

                newModel = this.FromCertificate(certificateInDb);
            }

            return Json(new[] { newModel }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, CertificateViewModel model)
        {
            var newModel = model;
            if (model != null && ModelState.IsValid)
            {
                var certificateInDb = this.Data.Certificates.GetById(model.Id);

                if (certificateInDb == null)
                {
                    return HttpNotFound();
                }

                this.Data.Certificates.Delete(certificateInDb);
                this.Data.SaveChanges();
            }

            return Json(new[] { newModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CertificateViewModel model)
        {
            var newModel = model;
            if (model != null && ModelState.IsValid)
            {
                var certificate = new Certificate()
                {
                    Title = model.Title,
                    IssueDate = DateTime.Now,
                    MinimalMark = model.MinimalMark,
                    Courses = new HashSet<Course>()
                };
                this.Data.Certificates.Add(certificate);
                this.Data.SaveChanges();

                newModel = this.FromCertificate(certificate);
            }

            return Json(new[] { newModel }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult GetCoursesList(int id)
        {
            var courses = this.Data.Courses.All();
            var model = new EditCertificateCoursesModel()
            {
                Id = id,
                Courses = courses.Select(CertificateCourseModel.FromCourse).ToList()
            };
            return PartialView(model);
        }

        public ActionResult EditCourse(EditCertificateCoursesModel model)
        {
            var certificateInDb = this.Data.Certificates.All(new string[] { "Courses" }).FirstOrDefault(c => c.Id == model.Id);
            var courseInCertificate = certificateInDb.Courses.FirstOrDefault(c => c.Id == model.CourseId);
            if (courseInCertificate == null)
            {
                var courseToAdd = this.Data.Courses.GetById(model.CourseId);
                certificateInDb.Courses.Add(courseToAdd);
            }
            else
            {
                var courseToRemove = this.Data.Courses.GetById(model.CourseId);
                certificateInDb.Courses.Remove(courseToRemove);
            }

            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        private CertificateViewModel FromCertificate(Certificate certificate)
        {
            var model = new CertificateViewModel();
            model.Id = certificate.Id;
            model.Title = certificate.Title;
            model.MinimalMark = certificate.MinimalMark;

            StringBuilder sb = new StringBuilder();
            foreach (var item in certificate.Courses)
            {
                sb.Append(item.Title + ",");
            }
            if (sb.Length > 0)
            {
                sb.Length--;
            }

            model.Courses = sb.ToString();

            return model;
        }
	}
}