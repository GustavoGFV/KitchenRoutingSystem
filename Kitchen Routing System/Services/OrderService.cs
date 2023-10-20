using Kitchen_Routing_System.Interface;
using Kitchen_Routing_System.Resource;

namespace Kitchen_Routing_System.Services
{
    /// <summary>
    /// O OrderService em si tem um desing bem basico, ele vai permanecer em execução enquanto não for dado a ele a informação de CancellationToken, neste modelo o CancellationToken não é utilizado.
    /// The OrderService itself has a very basic desing, it will remain running until it is given the CancellationToken information, but in this model CancellationToken is not used.
    /// </summary>
    public class OrderService : BackgroundService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderQueue _orderQueue;
        private readonly IProcessOrder _processOrder;

        public OrderService(ILogger<OrderService> logger, IOrderQueue orderQueue, IProcessOrder processOrder)
        {
            _logger = logger;
            _orderQueue = orderQueue;
            _processOrder = processOrder;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var order = await _orderQueue.Dequeue();
                    if (order != null)
                    {
                        await _processOrder.ProcessOrderAsync(order);
                    }

                    ///Previnir gargalo/atraso
                    ///Delay to avoid busy-wait
                    await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
                    ///Outra opção seria o Thread.Sleep
                    ///Other option would be Thread.Sleep
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Error.ProcessError);
            }
        }
    }
}
