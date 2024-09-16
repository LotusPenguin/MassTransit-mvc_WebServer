using MassTransit;
using MessageTypes;

namespace KSR_Docker.Models.Consumers
{
    public class RoomsConsumer : IConsumer<IRoomsResponse>
    {
        public Task Consume(ConsumeContext<IRoomsResponse> context)
        {
            return Task.CompletedTask;
        }
    }
}