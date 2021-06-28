namespace DAL.Interfaces.EntityInterfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
