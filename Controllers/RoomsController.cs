using KSR_Docker.Models.Models;
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

namespace KSR_Docker.Controllers
{
    public class RoomsController
    {
        private static RoomsController Instance;
        //private static HandlerClass ResponseHandler;
        private static int TimeoutMs = 5000;
        private ISendEndpoint SendEndpoint { get; set; }

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

        private RoomsController(IRequestClient<RoomsQuery> client)
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

        public async Task<IActionResult> GetRooms()
        {
            //throw new NotImplementedException();
            //TODO
            var response = await _client.GetResponse<IRoomsResponse>(new RoomsQuery());
            return Ok((List<Room>)response.Message.Message);
        }

        public void AddRoom(string name, string status, int roomType)
        {
            //TODO
        }

        public void RemoveRoom(int roomId)
        {
            //TODO
        }
    }
}
