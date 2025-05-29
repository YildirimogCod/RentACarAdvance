namespace Core.Persistence.Dynamic
{
    public class Sort
    {
        public string Field { get; set; }
        
        public string Dir { get; set; }


        public Sort()
        {
            Field = string.Empty;
            Dir = string.Empty;
        }
        public Sort(string field, string direction)
        {
            Field = field;
            Dir = direction;
        }
    }
}
