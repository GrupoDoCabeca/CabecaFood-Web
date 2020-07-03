namespace BusinessLogicalLayer.Models.UserModel
{
    public class UserUpdateRequestModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
