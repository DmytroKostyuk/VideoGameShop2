using DAL.Interfaces.EntityInterfaces;

namespace DAL.Entities
{
    public class Genre : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
