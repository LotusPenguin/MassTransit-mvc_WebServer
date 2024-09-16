using KSR_Docker.Models.Models;
using KSR_Docker.Models.Errors;
using KSR_Docker.Models.QueryClasses;
using KSR_Docker.Models.CommandClasses;
using KSR_Docker.Models.Repositories;
using MassTransit;
using MassTransit.Clients;
using MassTransit.Serialization;
using MassTransit.Testing;
using MessageTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

namespace KSR_Docker.Controllers
{
    public class RoomsController : Controller
    {
        //private static int TimeoutMs = 5000;

        IRequestClient<RoomsQuery> _queryClient;
        IRequestClient<RoomUpdateCommand> _roomUpdateClient;
        IRequestClient<RoomDeleteCommand> _roomDeleteClient;

        public RoomsController(
            IRequestClient<RoomsQuery> queryClient, 
            IRequestClient<RoomUpdateCommand> roomUpdateClient, 
            IRequestClient<RoomDeleteCommand> roomDeleteClient)
        {
            _queryClient = queryClient;
            _roomUpdateClient = roomUpdateClient;
            _roomDeleteClient = roomDeleteClient;
        }

        //[HttpPost]
        //[Route("/init")]
        //public ActionResult InitRepository()
        //{
        //    return RedirectToAction("Rooms", "Rooms");
        //}

        [HttpGet]
        [Route("rooms/list")]
        public async Task<IActionResult> Rooms()
        {
            var request = _queryClient.Create(new RoomsQuery());
            var response = await request.GetResponse<IRoomsResponse>();
            List<Room>? rooms = new List<Room>();
            
            if(response.Message.Text != null)
            {
                rooms = JsonConvert.DeserializeObject<List<Room>>(response.Message.Text);
            }
            return View(rooms);
        }

        [HttpPost]
        [Route("/rooms/add")]
        public async Task<IActionResult> AddRoom(int id, string name, int roomType, string status)
        {
            var request = _roomUpdateClient.Create(new RoomUpdateCommand() { 
                RoomId = id, 
                Name = name, 
                RoomType = roomType, 
                Status = status
            });
            var response = await request.GetResponse<IRoomsResponse>();

            //TODO: handle response message

            return RedirectToAction("Rooms");
        }

        [HttpGet]
        [Route("rooms/delete/{roomId}")]
        public async Task<IActionResult> RemoveRoom(int roomId)
        {
            Console.WriteLine("### RoomID: " + roomId);
            var request = _roomDeleteClient.Create(new RoomDeleteCommand() { 
                RoomId = roomId 
            });

            var response = await request.GetResponse<IRoomsResponse>();

            //TODO: handle response message

            return RedirectToAction("Rooms");
        }
    }
}
