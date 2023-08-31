using Kitchen_Routing_System.Dto;
using Kitchen_Routing_System.Dto.Enum;
using Kitchen_Routing_System.Interface;
using Kitchen_Routing_System.Resource;
using Kitchen_Routing_System.Services.Process.AreaProcess;

namespace Kitchen_Routing_System.Services.Process
{
    public class ProcessOrder: IProcessOrder
    {
        private readonly ILogger<OrderService> _logger;
        private readonly ProcessSalad _processSalad;
        private readonly ProcessGrill _processGrill;
        private readonly ProcessDesert _processDesert;
        private readonly ProcessDrink _processDrink;
        private readonly ProcessFries _processFries;

        public ProcessOrder(ILogger<OrderService> logger, ProcessSalad processSalad, ProcessDesert processDesert, ProcessGrill processGrill, ProcessDrink processDrink, ProcessFries processFries)
        {
            _logger = logger;
            _processSalad = processSalad;
            _processGrill = processGrill;
            _processDesert = processDesert;
            _processDrink = processDrink;
            _processFries = processFries;
        }
        /// <summary>
        /// In here is a simple process to log for each area the order was made, its nothing complex because i didnt know what would it be the next step for a kitchen.
        /// Aqui é a parte mais simples aonde é registrado um log para cada area que o pedido foi feito, não é muito complexo pois não sabia os proximos passos de uma cozinha.
        /// </summary>
        public async Task ProcessOrderAsync(KitchenOrderDto kitchenOrder)
        {
            foreach (var area in kitchenOrder.Description)
            {
                switch (area.Area)
                {
                    case AreaEnum.Salad:
                        {
                            await _processSalad.ProcessSaladOrder(kitchenOrder);
                            break;
                        }
                    case AreaEnum.Grill:
                        {
                            await _processGrill.ProcessGrillOrder(kitchenOrder);
                            break;
                        }
                    case AreaEnum.Desert:
                        {
                            await _processDesert.ProcessDesertOrder(kitchenOrder);
                            break;
                        }
                    case AreaEnum.Drink:
                        {
                            await _processDrink.ProcessDrinkOrder(kitchenOrder);
                            break;
                        }
                    case AreaEnum.Fries:
                        {
                            await _processFries.ProcessFriesOrder(kitchenOrder);
                            break;
                        }
                    default:
                        _logger.LogWarning(string.Format(Error.UnknownArea, area.Area));
                        break;
                }
            }            
        }
    }
}
