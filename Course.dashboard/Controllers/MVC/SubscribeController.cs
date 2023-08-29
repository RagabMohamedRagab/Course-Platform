using Course.Repository.IRepositories;
using Course.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Course.dashboard.Controllers.MVC {
    public class SubscribeController : Controller {
        private readonly ISubscribeService _subscribe;

        public SubscribeController(ISubscribeService subscribe)
        {
            _subscribe = subscribe;
        }                  
        [HttpGet]  
        public IActionResult Index()
        {
            return View() ;
        }       
        [HttpGet]  
        public JsonResult Get()
        {
            return Json(_subscribe.GetSubscriptions("Test123@gmail.com").Result) ;
        }
    }
}
