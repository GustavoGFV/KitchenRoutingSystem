using Kitchen_Routing_System.Dto;
using Kitchen_Routing_System.Resource;

namespace Kitchen_Routing_System.Services.Process.AreaProcess
{
    public class ProcessFries
    {
        private readonly ILogger<OrderService> _logger;

        public ProcessFries(ILogger<OrderService> logger)
        {
            _logger = logger;
        }
        public Task ProcessFriesOrder(KitchenOrderDto kitchenOrder)
        {
            _logger.LogInformation(string.Format(Success.FriesOrder, kitchenOrder.OrderId));
            return Task.CompletedTask;
        }
    }
}
