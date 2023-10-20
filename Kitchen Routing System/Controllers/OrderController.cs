using Kitchen_Routing_System.Dto;
using Kitchen_Routing_System.Interface;
using Kitchen_Routing_System.Resource;
using Kitchen_Routing_System.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen_Routing_System.Controllers
{
    /// <summary>
    /// For the controller i tried to add something more than just the post option, to try to get the current queue and the logs to try to inform yourself to what has already been completed or not.
    /// Para o controller tentei adicionar algo alem da opção de post, colocando uma opção para listar a queue e uma opção para verificar os logs.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderQueue _orderQueue;
        private OrderValidation _orderValidation;

        public OrderController(ILogger<OrderController> logger, IOrderQueue orderQueue, OrderValidation orderValidation)
        {
            _logger = logger;
            _orderQueue = orderQueue;
            _orderValidation = orderValidation;
        }

        [HttpPost]
        public async Task<IActionResult> Post(KitchenOrderDto kitchenOrder)
        {
            try
            {
                //Reduzir linhas de validação com o FluentValidation
                //Reduce validation lines with FluentValidation
                var result = _orderValidation.Validate(kitchenOrder);
                if (!result.IsValid)
                    foreach (var error in result.Errors)
                        throw new Exception(error.ErrorMessage);

                _orderQueue.Enqueue(kitchenOrder);
                _logger.LogInformation(string.Format(Success.AddToQueue, kitchenOrder.OrderId));
                return Ok(string.Format(Success.AddToQueue, kitchenOrder.OrderId));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, Error.PostError);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get/Queue")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _orderQueue.ListQueue());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Error.GetError);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get/Logs")]
        public IActionResult GetLog()
        {
            try
            {
                using (FileStream fileStream = new FileStream(FilePath.File, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        return Ok(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Error.GetLogError);
                return BadRequest(ex.Message);
            }
        }
    }
}