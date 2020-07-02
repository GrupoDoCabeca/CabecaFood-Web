using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.Order_SnackModel;
using Domain.FluentValidations.HBSIS.Padawan.Produtos.Domain;
using Infra.IRepositories;
using Microsoft.EntityFrameworkCore.Internal;
using Shared.CustomsExceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class Order_SnackService : IOrder_SnackService
    {

        private readonly IOrder_SnackRepository _order_SnackRepository;

        public Order_SnackService(IOrder_SnackRepository order_SnackRepository)
        {
            _order_SnackRepository = order_SnackRepository;
        }

        public async Task<Order_SnackResponseModel> Create(Order_SnackRequestModel order_SnackModel)
        {
            var errors = new HashSet<Error>();

            var order_Snack = Order_SnackMap.Order_SnackRequestToOrder_Snack(order_SnackModel);

            if (order_Snack.OrderId < 1)
                errors.Add(new Error("Pedido", "Invalido"));

            if (order_Snack.SnackId <= 1)
                errors.Add(new Error("Lanche", "Invalido"));

            if (errors.Any())
                throw new BadRequestException(errors);

            await _order_SnackRepository.Create(order_Snack);

            return Order_SnackMap.Order_SnackToOrder_SnackResponse(order_Snack);
        }
    }
}
