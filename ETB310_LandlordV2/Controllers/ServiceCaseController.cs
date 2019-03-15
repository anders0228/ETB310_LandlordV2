using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETB310_LandlordV2.Models;

namespace ETB310_LandlordV2.Controllers
{
    public class ServiceCaseController : Controller
    {
        // GET: ServiceCase
        [Authorize]
        public ActionResult Index()
        {

            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();

            var serviceCaseList = new List<ServiceCaseViewModel>();
            foreach (ServiceReference1.ServiceCase caseInstance in service.GetAllCases())
            {
                serviceCaseList.Add(new ServiceCaseViewModel()
                {
                    CaseNr = caseInstance.CaseNr,
                    Date = caseInstance.Date,
                    FlatNr = caseInstance.FlatNr,
                    Name = caseInstance.Name,
                    ContactEmail = caseInstance.ContactEmail
                });
            }

            return View(serviceCaseList);
        }

        //Shows a service case with all connected posts
        [Authorize]
        public ActionResult ShowServicCase(int caseNr)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            var posts = new List<ServiceCasePostViewModel>();
            foreach (ServiceReference1.ServiceCasePost post in client.GetCase(caseNr).Posts)
            {
                ServiceCasePostViewModel serviceCasePost = new ServiceCasePostViewModel();
                serviceCasePost.CaseMessage = post.Message;
                serviceCasePost.Name = post.Name;
                serviceCasePost.ContactEmail = post.ContactEmail;
                serviceCasePost.Private = post.Private;
                posts.Add(serviceCasePost);
            }
            var vm = new ServiceCaseViewModel();
            vm.CaseNr = caseNr;
            vm.Posts = posts;
            return View(vm);
        }
    }
}