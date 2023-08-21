using Kitchen_Routing_System.Dto;
using Kitchen_Routing_System.Resource;

namespace Kitchen_Routing_System.Services.Process.AreaProcess
{
    public class ProcessDesert
    {
        private readonly ILogger<OrderService> _logger;

        public ProcessDesert(ILogger<OrderService> logger)
        {
            _logger = logger;
        }
        public Task ProcessDesertOrder(KitchenOrderDto kitchenOrder)
        {
            _logger.LogInformation(string.Format(Success.DesertOrder, kitchenOrder.OrderId));
            return Task.CompletedTask;
        }
    }
}
