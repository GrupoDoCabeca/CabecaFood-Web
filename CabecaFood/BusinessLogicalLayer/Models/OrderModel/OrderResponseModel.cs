using BusinessLogicalLayer.Models.Interface;
using BusinessLogicalLayer.Models.SnackModel;
using System.Collections.Generic;

namespace BusinessLogicalLayer.Models.OrderModel
{
    public class OrderResponseModel : OrderRequestModel, IResponseModel
    {
        public int Id { get; set; }
        public List<SnackResponseModel> Snacks { get; set; } = new List<SnackResponseModel>();
    }
}
