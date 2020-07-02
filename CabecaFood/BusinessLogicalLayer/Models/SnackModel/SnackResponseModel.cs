using BusinessLogicalLayer.Models.Interface;

namespace BusinessLogicalLayer.Models.SnackModel
{
    public class SnackResponseModel : SnackRequestModel, IResponseModel
    {
        public int Id { get; set; }
    }
}
