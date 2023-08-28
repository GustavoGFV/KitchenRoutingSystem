using FluentValidation;
using Kitchen_Routing_System.Dto;
using Kitchen_Routing_System.Resource;

namespace Kitchen_Routing_System.Validation
{
    public class OrderValidation : AbstractValidator<KitchenOrderDto>
    {
        public OrderValidation()
        {
            RuleFor(log => log.OrderId).NotNull()
             .WithMessage(Error.OrderIdNull);

            RuleFor(log => log.EstablishmentId).NotNull().NotEqual(0)
             .WithMessage(Error.EstablishmentInvalid);

            RuleFor(log => log.POS).NotNull().NotEqual(0)
             .WithMessage(Error.POSInvalid);
        }
    }
}
