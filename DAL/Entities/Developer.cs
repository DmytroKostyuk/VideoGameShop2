using DAL.Interfaces.EntityInterfaces;

namespace DAL.Entities
{
    public class Developer : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Id_Publisher { get; set;}
    }
}
