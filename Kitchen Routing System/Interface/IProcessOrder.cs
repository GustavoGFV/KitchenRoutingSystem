using Kitchen_Routing_System.Dto;

namespace Kitchen_Routing_System.Interface
{
    public interface IProcessOrder
    {
        Task ProcessOrderAsync(KitchenOrderDto kitchenOrder);
    }
}
