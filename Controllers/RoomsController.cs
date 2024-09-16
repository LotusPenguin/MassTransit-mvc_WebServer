using KSR_Docker.Models.Models;
using KSR_Docker.Models.Errors;
using KSR_Docker.Models.QueryClasses;
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
        //private static RoomsController Instance;
        //private static HandlerClass ResponseHandler;
        private static int TimeoutMs = 5000;
        //private ISendEndpoint SendEndpoint { get; set; }

        //private RoomRepository RoomRepository;

        IRequestClient<RoomsQuery> _client;

        //public static RoomsController GetInstance(IRequestClient<RoomsQuery> client)
        //{
        //    if (Instance == null)
        //    {
        //        Instance = new RoomsController(client);
        //    }
        //    Console.WriteLine("debug");
        //    return Instance;
        //}

        public RoomsController(IRequestClient<RoomsQuery> client)
        {
            _client = client;
            //RoomRepository = RoomRepository.GetInstance();
        }

        //private IBusControl InitializeResponseBus()
        //{
        //    var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
        //    {
        //        sbc.Host(new Uri("rabbitmq://cow.rmq2.cloudamqp.com/uklfscur"), h =>
        //        {
        //            h.Username("uklfscur");
        //            h.Password("l-2PHIXrRbG2lreh61yvypU6sx4dPGoi");
        //        });
        //        sbc.ReceiveEndpoint("responsequeue", ep =>
        //        {
        //            ep.Instance(ResponseHandler);
        //            ep.UseMessageRetry(r =>
        //            {
        //                r.Immediate(5);
        //            });
        //        });
        //    });
        //    return bus;
        //}
        //private IBusControl InitializeQueryBus()
        //{
        //    var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
        //    {
        //        sbc.Host(new Uri("rabbitmq://cow.rmq2.cloudamqp.com/uklfscur"), h =>
        //        {
        //            h.Username("uklfscur");
        //            h.Password("l-2PHIXrRbG2lreh61yvypU6sx4dPGoi");
        //        });
        //    });

        //    var task = bus.GetSendEndpoint(new Uri("rabbitmq://cow.rmq2.cloudamqp.com/uklfscur/queryqueue"));
        //    bool result = task.Wait(5000);
        //    if(result)
        //    {
        //        SendEndpoint = task.Result;
        //    }
        //    else
        //    {
        //        //todo
        //        throw new TimeoutException();
        //    }
        //    return bus;
        //}

        //public void InitRepository()
        //{
        //    RoomRepository.Init();
        //}

        [HttpPost]
        [Route("/init")]
        public ActionResult InitRepository()
        {
            return RedirectToAction("Rooms", "Rooms");
        }

        [HttpGet]
        [Route("rooms/list")]
        public async Task<IActionResult> Rooms()
        {
            //TODO
            var request = _client.Create(new RoomsQuery());
            var response = await request.GetResponse<IRoomsResponse>();
            List<Room>? rooms = new List<Room>();

            Console.WriteLine(response.Message.Text);
            
            if(response.Message.Text != null)
            {
                rooms = JsonConvert.DeserializeObject<List<Room>>(response.Message.Text);
            }
            return View(rooms);
        }

        //public ActionResult Rooms()
        //{
        //    //List<Room> rooms = AdminService.GetRooms().Result;
        //    return View();
        //}

        [HttpGet]
        [Route("/rooms/add")]
        public ActionResult AddRoom(string name, string status, int roomType)
        {
            //TODO
            return RedirectToAction("Rooms");
        }

        [HttpGet]
        [Route("rooms/delete/{id}")]
        public ActionResult RemoveRoom(int roomId)
        {
            //TODO
            return RedirectToAction("Rooms");
        }
    }
}
