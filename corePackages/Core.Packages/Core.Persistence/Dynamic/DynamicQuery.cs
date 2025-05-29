namespace Core.Persistence.Dynamic
{
    public class DynamicQuery
    {
        public Filter? Filter { get; set; }
        public IEnumerable<Sort> Sort { get; set; }
        public DynamicQuery()
        {
            
        }
        public DynamicQuery(Filter? filters, IEnumerable<Sort>? sort)
        {
            Filter = filters;
            Sort = sort;
          
        }
    }
}
