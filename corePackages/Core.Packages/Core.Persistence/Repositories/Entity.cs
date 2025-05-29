namespace Core.Persistence.Repositories
{
    public class Entity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Entity()
        {
            
        }
        public Entity(TId id)
        {
            Id = id;
        }
    }
}
