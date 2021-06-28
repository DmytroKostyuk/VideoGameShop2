namespace BLL.DTO
{
    public class UserChangePasswordDTO
    {
        public int Id { get; set; }

        public string NewPassword { get; set; }

        public string OldPassword { get; set; }
    }
}
