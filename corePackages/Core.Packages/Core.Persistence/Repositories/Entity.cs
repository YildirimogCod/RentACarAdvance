namespace Core.Persistence.Repositories
{
    public class Entity<TId>:IEntityTimestamps
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
