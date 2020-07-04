using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.OrderModel;
using Domain.Entities;
using Infra.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLogicalLayer.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IDeliveryManRepository _deliveryManRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISnackRepository _snackRepository;
        private readonly IRestaurantRepository _restaurantRepository;


        public OrderService(IOrderRepository orderRepository, IDeliveryManRepository deliveryManRepository, IUserRepository userRepository, ISnackRepository snackRepository, IRestaurantRepository restaurantRepository)
        {
            _orderRepository = orderRepository;
            _deliveryManRepository = deliveryManRepository;
            _userRepository = userRepository;
            _snackRepository = snackRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task<OrderResponseModel> AddDelivery(int orderId, int deliveryId)
        {
            ValidateId(orderId);
            ValidateId(deliveryId);

            HandleError();

            var deliveryMan = await _deliveryManRepository.GetById(deliveryId);

            if (deliveryMan == null)
                AddError("Entregador", "Não encontrado");

            var order = await _orderRepository.GetById(orderId);

            if (order == null)
                AddError("Pedido", "Não encontrado");

            HandleError();

            order.AddDeliveryMan(deliveryId);

            await _orderRepository.Update(order);
            await _orderRepository.Save();

            return OrderMap.OrderToOrderResponse(order);
        }

        public async Task<OrderResponseModel> Create(int restaurantId, OrderRequestModel orderModel)
        {
            orderModel.RestaurantId = restaurantId;
            var order = OrderMap.OrderRequestToOrder(orderModel);

            Validate(order);

            var user = await _userRepository.GetById(order.UserId);

            if (user == null)
                AddError("Usuario", "Não encontrado");

            var restaurant = await _restaurantRepository.GetById(orderModel.RestaurantId);

            if (restaurant == null)
                AddError("Restaurante", "Não encontrado");

            HandleError();

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _orderRepository.Create(order);
                await _orderRepository.Save();

                foreach (var snackId in orderModel.SnacksId)
                {

                    var snack = await _snackRepository.GetById(snackId);

                    if (snack == null || snack.RestaurantId != restaurantId)
                        AddError("Lanche", "Não encontrado");

                    HandleError();

                    snack.SetOrderId(order.Id);
                    await _snackRepository.Update(snack);
                }

                await _snackRepository.Save();
                scope.Complete();
            }

            return OrderMap.OrderToOrderResponse(order);
        }

        public async Task<OrderResponseModel> Delete(int restaurantId, int id)
        {
            var order = await _orderRepository.GetById(id);

            if (order == null || order.RestaurantId != restaurantId)
                AddError("Pedido", "Invalido");

            HandleError();

            await _orderRepository.Delete(id);
            await _orderRepository.Save();

            return OrderMap.OrderToOrderResponse(order);
        }

        public async Task<OrderResponseModel> GetById(int restaurantId, int id)
        {
            var order = await _orderRepository.GetById(id);

            if (order == null || order.RestaurantId != restaurantId)
                AddError("Pedido", "Invalido");

            HandleError();

            return OrderMap.OrderToOrderResponse(order);
        }

        public async Task<List<OrderResponseModel>> GetByRestaurantId(int restaurantId)
        {
            var orders = await _orderRepository.GetByRestaurantId(restaurantId);
            return orders.Select(x => OrderMap.OrderToOrderResponse(x)).ToList();
        }

        public override void Validate(Order entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            HandleError();
        }
    }
}
