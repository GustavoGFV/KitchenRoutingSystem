using Kitchen_Routing_System.Dto;
using Kitchen_Routing_System.Resource;

namespace Kitchen_Routing_System.Services.Process.AreaProcess
{
    public class ProcessSalad
    {
        private readonly ILogger<OrderService> _logger;

        public ProcessSalad(ILogger<OrderService> logger)
        {
            _logger = logger;
        }
        public Task ProcessSaladOrder(KitchenOrderDto kitchenOrder)
        {
            _logger.LogInformation(string.Format(Success.SaladOrder,kitchenOrder.OrderId));
            return Task.CompletedTask;
        }
    }
}
