using DAL.Interfaces.EntityInterfaces;

namespace DAL.Entities
{
    public class UserBought : IEntity<int>
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public int Id_Game { get; set; }

    }
}
