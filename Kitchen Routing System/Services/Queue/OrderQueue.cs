using Kitchen_Routing_System.Dto;
using Kitchen_Routing_System.Interface;
using Kitchen_Routing_System.Resource;

namespace Kitchen_Routing_System.Services.Queue
{
    public class OrderQueue : IOrderQueue
    {
        private readonly Queue<KitchenOrderDto> _queue = new Queue<KitchenOrderDto>();

        public void Enqueue(KitchenOrderDto kitchenOrder)
        {
            lock (_queue)
            {
                //Caso o numero do pedido tenha sido criado no mesmo dia, com o mesmo numero no mesmo estabelicimento sera disparado um erro.
                //A logica seria de que a cada dia a fila de pedidos reinicia
                //In case that the order id in the same date and in the same establishment already exists it will throw an exception.
                //The logic would be that each day the queue of requests restarts
                if (_queue.Count > 0 && _queue.Select(s => s.OrderId == kitchenOrder.OrderId &&
                                       s.CreatedAt.Day == kitchenOrder.CreatedAt.Day &&
                                       s.EstablishmentId == kitchenOrder.EstablishmentId).First())
                    throw new Exception(string.Format(Error.OrderIdExists, kitchenOrder.OrderId));

                _queue.Enqueue(kitchenOrder);
            }
        }
        public async Task<KitchenOrderDto> Dequeue()
        {
            lock (_queue)
            {
                return _queue.Dequeue();
            }
        }
        public async Task<Queue<KitchenOrderDto>> ListQueue()
        {
            return _queue;
        }
    }
}
