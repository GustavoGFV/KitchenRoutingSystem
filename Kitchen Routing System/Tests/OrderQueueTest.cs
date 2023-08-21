using Kitchen_Routing_System.Dto;
using Kitchen_Routing_System.Dto.Enum;
using Kitchen_Routing_System.Services.Queue;
using Xunit;

namespace Kitchen_Routing_System.Tests
{
    public class OrderQueueTest
    {
        [Fact]
        public void Enqueue_NewOrder_Success()
        {
            // Setup 
            var orderQueue = new OrderQueue();

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

            // Queue Test | Testar fila
            orderQueue.Enqueue(order);

            // Assert
            var queue = orderQueue.ListQueue().Result;
            Assert.Contains(order, queue);
        }

        [Fact]
        public void Enqueue_DuplicateOrderId_ThrowsException()
        {
            // Setup 
            var orderQueue = new OrderQueue();

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

            // Queue Test | Testar fila
            orderQueue.Enqueue(order);

            // Assert
            Assert.Throws<Exception>(() => orderQueue.Enqueue(order));
        }

        [Fact]
        public void Dequeue_EmptyQueue_ReturnsNull()
        {
            // Setup
            var orderQueue = new OrderQueue();

            // Act | Ação
            var dequeuedOrder = orderQueue.Dequeue().Result;

            // Assert
            Assert.Null(dequeuedOrder);
        }

        [Fact]
        public void Dequeue_NonEmptyQueue_Success()
        {
            // Setup
            var orderQueue = new OrderQueue();

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

            // Act| Ação
            var dequeuedOrder = orderQueue.Dequeue().Result;

            // Assert
            Assert.Equal(order, dequeuedOrder);
        }
    }
}
