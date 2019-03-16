using ETB310_LandlordV2.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;

namespace ETB310_LandlordV2.Controllers
{
    public class EditServiceCaseController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                var service = new ServiceReference1.Service1Client();
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
                return View(serviceCaseList.OrderByDescending(post => post.Date));
            }
            catch (CommunicationException ex)
            {
                // Ifall webbservicen inte hittades e.d.
                //errorLog.Add(new ErrorLogItem("CommunicationException", ex.Message));
                // TODO: Mejla alla uppkomna fel till en admin-webbadress
                Debug.WriteLine("ERROR: " + ex.Message);
                var serviceCaseList = new List<ServiceCaseViewModel>();
                ViewBag.ApplicationError = "Applikationsfel: Lyckades inte ansluta till webbtjänsten";
                return View(serviceCaseList);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult ShowServiceCase(int caseNr)
        {
            var vm = new ServiceCaseViewModel
            {
                CaseNr = caseNr
            };
            GetServiceCase(vm);
            return View(vm);
        }

        // Shows a service case with all connected posts
        [Authorize]
        [HttpPost]
        public ActionResult ShowServiceCase(ServiceCaseViewModel vm)
        {
            GetServiceCase(vm);
            return View(vm);
        }

        [Authorize]
        public ActionResult AddServiceCasePost(ServiceCaseViewModel vm)
        {
            if (ModelState["NewPostMessage"].Errors.Count == 0)
            {
                var client = new ServiceReference1.Service1Client();
                var post = new ServiceReference1.ServiceCasePost
                {
                    Name = User.Identity.Name,
                    Message = vm.NewPostMessage,
                    Private = vm.NewPostPrivate,
                };
                var result = client.AddPost(vm.CaseNr, post);
                return RedirectToAction("ShowServiceCase", new { vm.CaseNr });
            }
            GetServiceCase(vm);
            return View("ShowServiceCase", vm);
        }

        private void GetServiceCase(ServiceCaseViewModel vm)
        {
            try
            {
                var client = new ServiceReference1.Service1Client();
                var serviceCase = client.GetCase(vm.CaseNr);
                var posts = new List<ServiceCasePostViewModel>();
                foreach (ServiceReference1.ServiceCasePost post in serviceCase.Posts)
                {
                    ServiceCasePostViewModel serviceCasePost = new ServiceCasePostViewModel
                    {
                        Date = post.Date,
                        Name = post.Name,
                        ContactEmail = post.ContactEmail,
                        Private = post.Private,
                        CaseMessage = post.Message,
                    };
                    posts.Add(serviceCasePost);
                }
                vm.Date = serviceCase.Date;
                vm.Name = serviceCase.Name;
                vm.FlatNr = serviceCase.FlatNr;
                vm.ContactEmail = serviceCase.ContactEmail;
                vm.NewPostName = User.Identity.Name;
                vm.Posts = posts.OrderByDescending(post => post.Date);
            }
            catch (CommunicationException ex)
            {
                // Ifall webbservicen inte hittades e.d.
                // TODO: Mejla uppkomna fel till en admin-webbadress
                Debug.WriteLine("ERROR: " + ex.Message);
                vm.Posts = new List<ServiceCasePostViewModel>();
                ViewBag.ApplicationError = "Applikationsfel: Lyckades inte ansluta till webbtjänsten";
            }
        }
    }
}