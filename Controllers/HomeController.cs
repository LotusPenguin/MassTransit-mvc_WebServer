using KSR_Docker.Models.Errors;
using KSR_Docker.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Diagnostics;
using MassTransit;
using KSR_Docker.Models.QueryClasses;

namespace KSR_Docker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //IRequestClient<RoomsQuery> _roomsQuery;
        //private RoomsController AdminService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //AdminService = RoomsController.GetInstance(_roomsQuery);
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //[Route("rooms/list")]
        //public ActionResult Rooms()
        //{
        //    List<Room> rooms = AdminService.GetRooms().Result;
        //    return View(rooms);
        //}

        //[HttpPost]
        //[Route("/rooms/add")]
        //public ActionResult AddRoom(string name, string status, int roomType)
        //{
        //    //AdminService.AddRoom(name, status, roomType);
        //    return RedirectToAction("Rooms");
        //}

        //[HttpGet]
        //[Route("rooms/delete/{id}")]
        //public ActionResult RemoveRoom(int id)
        //{
        //    //AdminService.RemoveRoom(id);
        //    return RedirectToAction("Rooms");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
