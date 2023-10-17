namespace Core.Domain
{
    public class Entity
    {
        public int Id { get; set; }
        public bool Active { get; set; } = true;
        public Entity()
        {

        }
        public Entity(int id) : this()
        {
            Id = id;
        }
    }
}
