using Kitchen_Routing_System.Dto;

namespace Kitchen_Routing_System.Interface
{
    public interface IOrderQueue
    {
        void Enqueue(KitchenOrderDto order);
        Task<KitchenOrderDto> Dequeue();
        Task<Queue<KitchenOrderDto>> ListQueue();
    }
}
