using Kitchen_Routing_System.Dto;
using Kitchen_Routing_System.Dto.Enum;
using Kitchen_Routing_System.Interface;
using Kitchen_Routing_System.Services;
using Kitchen_Routing_System.Services.Process;
using Kitchen_Routing_System.Services.Queue;
using Moq;
using System.Threading;
using Xunit;

namespace Kitchen_Routing_System.Tests
{
    public class OrderServiceTest
    {
        [Fact]
        public void ProcessOrderAsync_Success()
        {
            //Setup
            var mockLogger = new Mock<ILogger<OrderService>>();
            var orderQueue = new OrderQueue();
            var processOrder = new Mock<IProcessOrder>();

            //Configure the object for the test | Configure o objeto para o teste
            var order = new KitchenOrderDto
            {
                Id = 1,
                OrderId = 1,
                EstablishmentId = 1,
                POS = 1,
                Name = "Test",
                Description = "Test",
                Area = AreaEnum.Drink,
                CreatedAt = DateTime.Now,
            };

            orderQueue.Enqueue(order);

            var cancellationTokenSource = new CancellationTokenSource();

            var orderService = new OrderService(mockLogger.Object, orderQueue, processOrder.Object);

            orderService.StartAsync(cancellationTokenSource.Token);

            // Simulate some delay to allow the service to process, adjust depending on the test | Simula um delay para realizar o teste, ajustar de acordo com o teste
            Task.Delay(TimeSpan.FromSeconds(2));

            cancellationTokenSource.Cancel(); // Cancel the service after a short delay | Cancela o serviço depois de um breve delay

            orderService.StopAsync(cancellationTokenSource.Token);
        }
    }
}
