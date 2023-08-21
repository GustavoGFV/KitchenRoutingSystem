using Kitchen_Routing_System.Dto;
using Kitchen_Routing_System.Resource;

namespace Kitchen_Routing_System.Services.Process.AreaProcess
{
    public class ProcessDrink
    {
        private readonly ILogger<OrderService> _logger;

        public ProcessDrink(ILogger<OrderService> logger)
        {
            _logger = logger;
        }

        public Task ProcessDrinkOrder(KitchenOrderDto kitchenOrder)
        {
            _logger.LogInformation(string.Format(Success.DrinkOrder, kitchenOrder.OrderId));
            return Task.CompletedTask;
        }
    }
}
