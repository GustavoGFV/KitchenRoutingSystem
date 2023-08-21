using Kitchen_Routing_System.Dto;
using Kitchen_Routing_System.Resource;

namespace Kitchen_Routing_System.Services.Process.AreaProcess
{
    public class ProcessGrill
    {
        private readonly ILogger<OrderService> _logger;

        public ProcessGrill(ILogger<OrderService> logger)
        {
            _logger = logger;
        }
        public Task ProcessGrillOrder(KitchenOrderDto kitchenOrder)
        {
            _logger.LogInformation(string.Format(Success.GrillOrder, kitchenOrder.OrderId));
            return Task.CompletedTask;
        }
    }
}
