using CertificateUserSystem.Data;
using CertificateUserSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationCertificateUserSystem.Models;

namespace WebApplicationCertificateUserSystem.Controllers
{
    [Authorize]
    [NoCache]
    [HandleError]
    public class ProfileController : BaseController
    {
        private HashSet<string> allowedFileExtensions =
            new HashSet<string> { "jpg", "jpeg", "png", "gif" };
        //
        // GET: /Profile/
        public ProfileController(IUowData data)
            : base(data)
        {
        }

        public ProfileController()
            : base()
        {
        }
        public ActionResult ShowProfile()
        {
            var userName = User.Identity.Name;
            var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == userName);
            if (string.IsNullOrEmpty(user.AvatarPath))
            {
                user.AvatarPath = "/img/Avatars/defaultAvatar.jpg";
            }
            return View(user);
        }

        [NoCache]
        [HandleError]
        public ActionResult Submit(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                var ext = Path.GetExtension(files.First().FileName);
                if (allowedFileExtensions.Contains(ext.Substring(1).ToLower()))
                {
                    var username = User.Identity.Name;

                    var fileName = username + ext;
                    var fullPath = Server.MapPath("~/img/Avatars/") + fileName;
                    files.First().SaveAs(fullPath);
                    var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                    user.AvatarPath = "/img/Avatars/" + fileName;
                    this.Data.SaveChanges();
                }
                else
                {
                    return RedirectToAction("ShowProfile");
                }

            }

            return RedirectToAction("ShowProfile");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CourseInstance course = this.Data.CourseInstances
                .All(new string[] { "Course" }).Where(c => c.Id == id).FirstOrDefault();

            if (course == null)
            {
                return HttpNotFound();
            }

            PublicCourseModel courseModel = new PublicCourseModel()
            {
                Description = course.Course.Description,
                Id = course.Id,
                LecturerName = course.Course.Lecturer,
                Title = course.Course.Title,
                EnrolledCount = this.Data.CourseInstances
                                    .All(new string[] { "Course" })
                                    .Where(c => c.Course.Id == id)
                                    .Count(),
                StartDate = course.StartDate,
                EndDate = course.EndDate
            };

            return View(courseModel);
        }

        public ActionResult Result()
        {
            return View();
        }


    }
}